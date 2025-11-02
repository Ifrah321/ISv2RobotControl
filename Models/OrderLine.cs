using Inventory_system.Models;

namespace Inventory_system.Models;

public class OrderLine
{
    public Item Item { get; }
    public int Quantity { get; }

    public OrderLine(Item item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }

    public override string ToString() => $"{Item.Name} × {Quantity}";
}