using System.Collections.Generic;
using System.Linq;
using Inventory_system.Models;

namespace Inventory_system.Models
{
    public class Inventory
    {
        private readonly Dictionary<Item, decimal> stock = new();

        public void Add(Item item, decimal amount)
        {
            if (stock.ContainsKey(item))
                stock[item] += amount;
            else
                stock[item] = amount;
        }

        public void ReduceStock(Item item, decimal amount)
        {
            if (stock.ContainsKey(item))
            {
                stock[item] -= amount;
                if (stock[item] < 0)
                    stock[item] = 0;
            }
        }

        public decimal GetStock(Item item)
        {
            return stock.TryGetValue(item, out var amount) ? amount : 0m;
        }

        public IEnumerable<Item> LowStockItems()
        {
            return stock.Where(s => s.Value < 5).Select(s => s.Key);
        }
    }
}