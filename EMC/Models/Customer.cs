using System;
using System.Collections.Generic;

namespace EMC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

#nullable enable
        public string? Address { get; set; }
        public string? Phone { get; set; }

#nullable disable
        public string Email { get; set; }

        public ICollection<Order> orders { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Customer customer { get; set; }
        public ICollection<ProductOrder> productOrders { get; set; }
    }

    public class ProductOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public Order order { get; set; }
        public Product product { get; set; }
    }
}