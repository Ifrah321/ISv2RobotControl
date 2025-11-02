using System.Collections.Generic;
using System.Linq;

namespace Inventory_system.Models;

public class OrderBook
{
    private readonly List<Order> _orders = new();

    public IReadOnlyList<Order> Orders => _orders;

    public void Add(Order order) => _orders.Add(order);
    
    public IEnumerable<OrderLine> ProcessNextOrder()
    {
        var next = _orders.OrderBy(o => o.Time).FirstOrDefault();
        if (next == null) yield break;

        _orders.Remove(next);
        foreach (var line in next.OrderLines)
            yield return line;
    }
}