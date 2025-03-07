using BarManagementSystem.DataAccess;
using BarManagementSystem.Models;
using System.Collections.Generic;

public class OrderService
{
    private DatabaseContext dbContext;

    public OrderService(DatabaseContext context)
    {
        dbContext = context;
    }

    public void DeleteOrder(int rowIndex)
    {
        // Implement DELETE query based on rowIndex or order ID
        // Example: dbContext.ExecuteNonQuery("DELETE FROM Orders WHERE OrderID = @ID", new { ID = rowIndex });
    }

    public void UpdateOrder(Order order)
    {
        // Implement UPDATE query
        // Example: dbContext.ExecuteNonQuery("UPDATE Orders SET Particular = @Particular, Size = @Size, ... WHERE OrderID = @ID", order);
    }

    public List<Order> GetOrders(int barID)
    {
        return dbContext.GetOrders(barID);
    }
}