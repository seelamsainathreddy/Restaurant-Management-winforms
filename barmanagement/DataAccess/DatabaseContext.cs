using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// DataAccess/DatabaseContext.cs
using System.Data.SQLite;
using BarManagementSystem.Models;

namespace BarManagementSystem.DataAccess
{
    public class DatabaseContext
    {
        private string dbPath = "bar_database.sqlite";
        private string connectionString;

        public DatabaseContext()
        {
            connectionString = "Data Source=" + dbPath + ";Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string[] createTableQueries = {
                    "CREATE TABLE IF NOT EXISTS Bar (BarID INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, address TEXT NOT NULL, phoneNumber TEXT NOT NULL, PassWord TEXT NOT NULL)",
                    "CREATE TABLE IF NOT EXISTS `Table` (tableID INTEGER PRIMARY KEY AUTOINCREMENT, BarID INTEGER NOT NULL, capacity INTEGER NOT NULL, isOccupied INTEGER NOT NULL DEFAULT 0, FOREIGN KEY (BarID) REFERENCES Bar(BarID) ON DELETE CASCADE)",
                    "CREATE TABLE IF NOT EXISTS Menu (menuID INTEGER PRIMARY KEY AUTOINCREMENT, BarID INTEGER NOT NULL, name TEXT NOT NULL, FOREIGN KEY (BarID) REFERENCES Bar(BarID) ON DELETE CASCADE)",
                    "CREATE TABLE IF NOT EXISTS MenuSection (sectionID INTEGER PRIMARY KEY AUTOINCREMENT, menuID INTEGER NOT NULL, name TEXT NOT NULL, types TEXT, FOREIGN KEY (menuID) REFERENCES Menu(menuID) ON DELETE CASCADE)",
                    "CREATE TABLE IF NOT EXISTS MenuItem (itemID INTEGER PRIMARY KEY AUTOINCREMENT, sectionID INTEGER NOT NULL, name TEXT NOT NULL, types TEXT, prices TEXT, isAvailable INTEGER NOT NULL DEFAULT 1, FOREIGN KEY (sectionID) REFERENCES MenuSection(sectionID) ON DELETE CASCADE)",
                    "CREATE TABLE IF NOT EXISTS `Order` (orderID INTEGER PRIMARY KEY AUTOINCREMENT, tableID INTEGER NOT NULL, totalAmount REAL NOT NULL DEFAULT 0.0, status TEXT NOT NULL DEFAULT 'pending', orderTime TEXT NOT NULL DEFAULT (datetime('now')), FOREIGN KEY (tableID) REFERENCES `Table`(tableID) ON DELETE CASCADE)",
                    "CREATE TABLE IF NOT EXISTS Order_MenuItem (orderID INTEGER NOT NULL, itemID INTEGER NOT NULL, PRIMARY KEY (orderID, itemID), FOREIGN KEY (orderID) REFERENCES `Order`(orderID) ON DELETE CASCADE, FOREIGN KEY (itemID) REFERENCES MenuItem(itemID) ON DELETE CASCADE)",
                    "CREATE TABLE IF NOT EXISTS Employee (employeeID INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, role TEXT NOT NULL, salary REAL NOT NULL)",
                    "CREATE TABLE IF NOT EXISTS Payment (paymentID INTEGER PRIMARY KEY AUTOINCREMENT, orderID INTEGER NOT NULL, amount REAL NOT NULL, paymentMethod TEXT NOT NULL, paymentDate TEXT NOT NULL DEFAULT (datetime('now')), FOREIGN KEY (orderID) REFERENCES `Order`(orderID) ON DELETE CASCADE)"
                };
                foreach (string query in createTableQueries)
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                // Insert a default Bar if none exists
                string insertBarQuery = "INSERT OR IGNORE INTO Bar (BarID, name, address, phoneNumber, PassWord) VALUES (1, 'My Bar', '123 Main St', '555-1234', 'password')";
                using (SQLiteCommand command = new SQLiteCommand(insertBarQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Insert default Tables
                string insertTablesQuery = "INSERT OR IGNORE INTO `Table` (tableID, BarID, capacity, isOccupied) VALUES (1, 1, 4, 0), (2, 1, 6, 0), (3, 1, 2, 0)";
                using (SQLiteCommand command = new SQLiteCommand(insertTablesQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Insert a default Menu
                string insertMenuQuery = "INSERT OR IGNORE INTO Menu (menuID, BarID, name) VALUES (1, 1, 'Main Menu')";
                using (SQLiteCommand command = new SQLiteCommand(insertMenuQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Insert default MenuSections
                string insertSectionsQuery = "INSERT OR IGNORE INTO MenuSection (sectionID, menuID, name, types) VALUES (1, 1, 'Whiskey', '100ml, 200ml'), (2, 1, 'Desserts', '')";
                using (SQLiteCommand command = new SQLiteCommand(insertSectionsQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Insert default MenuItems
                string insertItemsQuery = "INSERT OR IGNORE INTO MenuItem (itemID, sectionID, name, types, prices, isAvailable) VALUES (1, 1, 'Jack Daniel''s', '100ml, 200ml', '10.00, 18.00', 1), (2, 1, 'Johnnie Walker', '100ml, 200ml', '12.00, 20.00', 1), (3, 2, 'Cheesecake', '', '5.00', 1)";
                using (SQLiteCommand command = new SQLiteCommand(insertItemsQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Table> GetTables(int barID)
        {
            List<Table> tables = new List<Table>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM `Table` WHERE BarID = @BarID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BarID", barID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Table table = new Table();
                            table.TableID = reader.GetInt32(0);
                            table.BarID = reader.GetInt32(1);
                            table.Capacity = reader.GetInt32(2);
                            table.IsOccupied = reader.GetInt32(3) == 1;
                            tables.Add(table);
                        }
                    }
                }
            }
            return tables;
        }

        public List<MenuSection> GetMenuSections(int menuID)
        {
            List<MenuSection> sections = new List<MenuSection>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM MenuSection WHERE menuID = @menuID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@menuID", menuID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuSection section = new MenuSection();
                            section.SectionID = reader.GetInt32(0);
                            section.MenuID = reader.GetInt32(1);
                            section.Name = reader.GetString(2);
                            section.Types = reader.IsDBNull(3) ? null : reader.GetString(3);
                            sections.Add(section);
                        }
                    }
                }
            }
            return sections;
        }

        public List<MenuItem> GetMenuItems(int sectionID)
        {
            List<MenuItem> items = new List<MenuItem>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM MenuItem WHERE sectionID = @sectionID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sectionID", sectionID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuItem item = new MenuItem();
                            item.ItemID = reader.GetInt32(0);
                            item.SectionID = reader.GetInt32(1);
                            item.Name = reader.GetString(2);
                            item.Types = reader.IsDBNull(3) ? null : reader.GetString(3);
                            item.Prices = reader.IsDBNull(4) ? null : reader.GetString(4);
                            item.IsAvailable = reader.GetInt32(5) == 1;
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        // Add more methods as needed (e.g., SaveOrder, GetOrders, etc.)
    }
}