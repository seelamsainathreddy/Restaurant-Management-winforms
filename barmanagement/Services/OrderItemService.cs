// DataAccess/OrderItemService.cs
using System.Collections.Generic;
using BarManagementSystem.Models;
using System.Data.SQLite;
using System;

namespace BarManagementSystem.DataAccess
{
    public class OrderItemService
    {
        private DatabaseContext dbContext;

        public OrderItemService(DatabaseContext context)
        {
            dbContext = context;
        }

        public List<OrderLineItem> GetOrderItems(int tableId)
        {
            List<OrderLineItem> items = new List<OrderLineItem>();
            using (var connection = new SQLiteConnection(dbContext.connectionString))
            {
                connection.Open();
                // First, find the order for the given tableId (assuming the most recent order)
                string orderQuery = "SELECT orderID FROM `Order` WHERE tableID = @TableID AND status = 'pending' ORDER BY orderTime DESC LIMIT 1";
                int orderId = -1;
                using (var orderCommand = new SQLiteCommand(orderQuery, connection))
                {
                    orderCommand.Parameters.AddWithValue("@TableID", tableId);
                    var result = orderCommand.ExecuteScalar();
                    if (result != null)
                    {
                        orderId = Convert.ToInt32(result);
                    }
                }

                if (orderId == -1)
                {
                    // No pending order found; return empty list
                    return items;
                }

                // Fetch order items
                string query = @"
                    SELECT om.*, mi.*
                    FROM Order_MenuItem om
                    JOIN MenuItem mi ON om.itemID = mi.itemID
                    WHERE om.orderID = @OrderID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new OrderLineItem
                            {
                                OrderId = reader.GetInt32(reader.GetOrdinal("orderID")),
                                ItemId = reader.GetInt32(reader.GetOrdinal("itemID")),
                                MenuItem = new MenuItem
                                {
                                    ItemID = reader.GetInt32(reader.GetOrdinal("itemID")),
                                    SectionID = reader.GetInt32(reader.GetOrdinal("sectionID")),
                                    Name = reader["name"].ToString(),
                                    Types = reader["types"].ToString(),
                                    Prices = reader["prices"].ToString(),
                                    IsAvailable = reader.GetInt32(reader.GetOrdinal("isAvailable")) == 1
                                },
                                SelectedType = reader["SelectedType"].ToString(),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                KOT = reader["KOT"].ToString()
                            };
                            item.Price = CalculatePrice(item.MenuItem, item.SelectedType);
                            item.Amount = (item.Quantity * double.Parse(item.Price)).ToString("F2");
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        private string CalculatePrice(MenuItem menuItem, string selectedType)
        {
            string[] types = menuItem.Types.Split(',');
            string[] prices = menuItem.Prices.Split(',');
            int index = Array.IndexOf(types, selectedType);
            if (index >= 0 && index < prices.Length)
            {
                return prices[index].Replace("rs", "").Trim();
            }
            return "0.00";
        }

        public void DeleteOrderItem(OrderLineItem item)
        {
            using (var connection = new SQLiteConnection(dbContext.connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Order_MenuItem WHERE orderID = @OrderID AND itemID = @ItemID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", item.OrderId);
                    command.Parameters.AddWithValue("@ItemID", item.ItemId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOrderItem(OrderLineItem item)
        {
            using (var connection = new SQLiteConnection(dbContext.connectionString))
            {
                connection.Open();
                string query = "UPDATE Order_MenuItem SET SelectedType = @SelectedType, Quantity = @Quantity, KOT = @KOT WHERE orderID = @OrderID AND itemID = @ItemID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedType", item.SelectedType);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Parameters.AddWithValue("@KOT", item.KOT);
                    command.Parameters.AddWithValue("@OrderID", item.OrderId);
                    command.Parameters.AddWithValue("@ItemID", item.ItemId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}