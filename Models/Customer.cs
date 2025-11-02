using System.Collections.Generic;

namespace Inventory_system.Models;

public class Customer
{
    public string Name { get; }
    public List<Order> Orders { get; } = new();

    public Customer(string name)
    {
        Name = name;
    }

    public void CreateOrder(OrderBook orderBook, Order order)
    {
        Orders.Add(order);
        orderBook.Add(order);
    }

    public override string ToString() => Name;
}