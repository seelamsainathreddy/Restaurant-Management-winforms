using System;
using System.Data;
using System.Data.SQLite;

namespace restaurantManagement
{
    public class DatabaseHelper
    {
        private static string connectionString = "Data Source=restaurant.db;Version=3;";

        public static DataTable GetTables()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tables";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static bool AddTable(string tableNumber, int capacity)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Check if table number already exists
                string checkQuery = "SELECT COUNT(*) FROM Tables WHERE Number = @Number";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Number", tableNumber);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        return false; // Table number already exists
                    }
                }

                // Insert new table if it doesn’t exist
                string query = "INSERT INTO Tables (Number, Capacity, Status) VALUES (@Number, @Capacity, 'Available')";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Number", tableNumber);
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
                    cmd.ExecuteNonQuery();

                    return true; // Successfully added
                }
            }
        }


        public static void ChangeTableStatus(int tableId, string newStatus)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Tables SET Status = @Status WHERE ID = @ID";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@ID", tableId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTable(int tableId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM Orders WHERE TableID = @TableID AND Status != 'Completed'";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@TableID", tableId);
                    int activeOrders = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (activeOrders == 0)
                    {
                        string query = "DELETE FROM Tables WHERE ID = @ID";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", tableId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        throw new Exception("Cannot delete table with active orders.");
                    }
                }
            }
        }


        // Fetch all pending orders
        public static DataTable GetOrders()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, TableID, WaiterID, Status, TotalAmount, CreatedAt FROM Orders WHERE Status = 'Pending'";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Fetch menu items
        public static DataTable GetMenuItems()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Name, Size, Price FROM MenuItems";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Fetch order items for an order
        public static DataTable GetOrderItems(int orderId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT OI.ID, M.Name, OI.Quantity, OI.Price FROM OrderItems OI JOIN MenuItems M ON OI.MenuItemID = M.ID WHERE OI.OrderID = @OrderID";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@OrderID", orderId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Add menu item to an order
        public static bool AddMenuItemToOrder(int orderId, int menuItemId, int quantity)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Get price of menu item
                string priceQuery = "SELECT Price FROM MenuItems WHERE ID = @MenuItemID";
                double price;
                using (SQLiteCommand cmd = new SQLiteCommand(priceQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MenuItemID", menuItemId);
                    price = Convert.ToDouble(cmd.ExecuteScalar());
                }

                double totalItemPrice = price * quantity;

                // Insert into OrderItems
                string query = "INSERT INTO OrderItems (OrderID, MenuItemID, Quantity, Price) VALUES (@OrderID, @MenuItemID, @Quantity, @Price)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@MenuItemID", menuItemId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", totalItemPrice);
                    cmd.ExecuteNonQuery();
                }

                // Update order total
                string updateTotalQuery = "UPDATE Orders SET TotalAmount = (SELECT SUM(Quantity * Price) FROM OrderItems WHERE OrderID = @OrderID) WHERE ID = @OrderID";
                using (SQLiteCommand cmd = new SQLiteCommand(updateTotalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
        }

        // Get Available Tables (Only those that are 'Available')
        public static DataTable GetAvailableTables()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Number FROM Tables WHERE Status = 'Available'";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Get All Waiters
        public static DataTable GetWaiters()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Name FROM Waiters";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Create a New Order
        public static int CreateOrder(int tableId, int waiterId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Orders (TableID, WaiterID, Status, TotalAmount) VALUES (@TableID, @WaiterID, 'Pending', 0); SELECT last_insert_rowid();";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TableID", tableId);
                    cmd.Parameters.AddWithValue("@WaiterID", waiterId);

                    // Execute and return the newly created Order ID
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
