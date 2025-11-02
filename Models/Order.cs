using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_system.Models;

public class Order
{
    public Customer Customer { get; set; }
    public List<OrderLine> OrderLines { get; set; } = new();
    public DateTime Time { get; set; }

    public Order(Customer customer)
    {
        Customer = customer;
        Time = DateTime.Now;
    }
    
    public override string ToString()
    {
        var totalItems = OrderLines.Sum(l => l.Quantity);
        var totalPrice = 500m; 
        return $"{Customer.Name} – {totalItems} item(s) – {totalPrice:0.00} kr";
    }
}