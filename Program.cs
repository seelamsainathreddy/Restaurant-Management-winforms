using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace restaurantManagement
{
    internal static class Program
    {
        private static string dbFileName = "restaurant.db";
        private static string connectionString = $"Data Source={dbFileName};Version=3;";

        [STAThread]
        static void Main()
        {
            Debug.WriteLine("Application Starting...");

            // Ensure database exists before launching the application
            InitializeDatabase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login()); // Make sure 'login' form exists
        }

        private static void InitializeDatabase()
        {
            try
            {
                Debug.WriteLine("Checking database existence...");

                // Check if database file exists
                if (!File.Exists(dbFileName))
                {
                    Debug.WriteLine("Database file not found. Creating a new one...");
                    SQLiteConnection.CreateFile(dbFileName);
                }
                else
                {
                    Debug.WriteLine("Database file exists.");
                }

                // Print database file path for debugging
                Debug.WriteLine("Database path: " + Path.GetFullPath(dbFileName));

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    Debug.WriteLine("Connected to database.");

                    // SQL Schema: Creating required tables
                    string createTablesQuery = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Role TEXT CHECK (Role IN ('Receptionist', 'Manager')) NOT NULL,
                            Password TEXT NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS Waiters (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Contact TEXT NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS Tables (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Number INTEGER UNIQUE NOT NULL,
                            Capacity INTEGER NOT NULL,
                            Status TEXT CHECK (Status IN ('Available', 'Occupied', 'Reserved')) NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS MenuSections (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL UNIQUE
                        );

                        CREATE TABLE IF NOT EXISTS MenuItems (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Size TEXT NOT NULL,
                            Price REAL NOT NULL,
                            SectionID INTEGER NOT NULL,
                            FOREIGN KEY (SectionID) REFERENCES MenuSections(ID)
                        );

                        CREATE TABLE IF NOT EXISTS Orders (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            TableID INTEGER NOT NULL,
                            WaiterID INTEGER NOT NULL,
                            Status TEXT CHECK (Status IN ('Pending', 'Completed', 'Cancelled')) NOT NULL,
                            TotalAmount REAL DEFAULT 0,
                            CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (TableID) REFERENCES Tables(ID),
                            FOREIGN KEY (WaiterID) REFERENCES Waiters(ID)
                        );

                        CREATE TABLE IF NOT EXISTS OrderItems (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            OrderID INTEGER NOT NULL,
                            MenuItemID INTEGER NOT NULL,
                            Quantity INTEGER NOT NULL,
                            Price REAL NOT NULL,
                            FOREIGN KEY (OrderID) REFERENCES Orders(ID),
                            FOREIGN KEY (MenuItemID) REFERENCES MenuItems(ID)
                        );

                        CREATE TABLE IF NOT EXISTS Payments (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            OrderID INTEGER NOT NULL,
                            Amount REAL NOT NULL,
                            PaymentType TEXT CHECK (PaymentType IN ('Cash', 'Card', 'Check')) NOT NULL,
                            Timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (OrderID) REFERENCES Orders(ID)
                        );";

                    using (SQLiteCommand command = new SQLiteCommand(createTablesQuery, conn))
                    {
                        command.ExecuteNonQuery();
                        Debug.WriteLine("✅ Tables created successfully.");
                    }

                    conn.Close();
                    Debug.WriteLine("Database connection closed.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("⚠️ ERROR: " + ex.Message);
            }
        }
    }
}
