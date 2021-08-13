using System;

namespace DapperFluentAPI.Domain.Entities.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
