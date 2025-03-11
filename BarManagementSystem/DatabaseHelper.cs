using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace barmanagement
{
    public static class DatabaseHelper
    {
        private static readonly string dbFileName = "bar_management.db"; // Database File
        private static readonly string connectionString = $"Data Source={dbFileName};Version=3;";

        /// <summary>
        /// Returns the SQLite connection string.
        /// </summary>
        public static string GetConnectionString()
        {
            return connectionString;
        }

        /// <summary>
        /// Initializes the database. Creates the database file and tables if they do not exist.
        /// </summary>
        public static void InitializeDatabase()
        {
            try
            {
                // Check if DB exists, create if not
                if (!File.Exists(dbFileName))
                {
                    SQLiteConnection.CreateFile(dbFileName);
                    Console.WriteLine("Database file created successfully.");
                }

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(GetCreateTablesSQL(), conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Database initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Initialization Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Executes a given SQL command.
        /// </summary>
        public static void ExecuteQuery(string query)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Execution Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves data from the database.
        /// </summary>
        public static DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Fetch Error: {ex.Message}");
            }
            return dt;
        }

        /// <summary>
        /// Generates the SQL script for creating required tables.
        /// </summary>
        private static string GetCreateTablesSQL()
        {
            return @"
                CREATE TABLE IF NOT EXISTS Bar (
                    BarID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Password TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS TableInfo (
                    TableNumber INTEGER PRIMARY KEY,
                    OccupiedStatus INTEGER NOT NULL CHECK (OccupiedStatus IN (0, 1)),
                    Category TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS MenuSection (
                    SectionId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    Types TEXT
                );

                CREATE TABLE IF NOT EXISTS MenuItem (
                    MenuItemId INTEGER PRIMARY KEY AUTOINCREMENT,
                    SectionId INTEGER,
                    Name TEXT NOT NULL,
                    ShortCode TEXT UNIQUE,
                    Prices DECIMAL(10,2) NOT NULL,
                    FOREIGN KEY (SectionId) REFERENCES MenuSection(SectionId) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS Orders (
                    OrderID INTEGER PRIMARY KEY AUTOINCREMENT,
                    TableID INTEGER,
                    TotalBill DECIMAL(10,2) NOT NULL DEFAULT 0.00,
                    Paid INTEGER DEFAULT 0 CHECK (Paid IN (0, 1)),
                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    EndedAt TIMESTAMP NULL,
                    FOREIGN KEY (TableID) REFERENCES TableInfo(TableNumber) ON DELETE SET NULL
                );

                CREATE TABLE IF NOT EXISTS OrderItem (
                    OrderID INTEGER,
                    MenuItemID INTEGER,
                    Type TEXT,
                    Price DECIMAL(10,2) NOT NULL,
                    Quantity INTEGER NOT NULL DEFAULT 1,
                    Status TEXT DEFAULT 'Pending',
                    PRIMARY KEY (OrderID, MenuItemID),
                    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
                    FOREIGN KEY (MenuItemID) REFERENCES MenuItem(MenuItemId) ON DELETE CASCADE
                );
            ";
        }
    }
}
