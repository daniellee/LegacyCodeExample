using System;

namespace LegacyCodeExample.Core
{
    public class OrderRepository
    {
        public OrderRepository(string databaseConnectionString)
        {
        }

        public Order GetOrderById(int orderId)
        {
            throw new Exception("Database not set up");
        }

        public void Save(Order order)
        {
            throw new Exception("Database not set up");
        }
    }
}