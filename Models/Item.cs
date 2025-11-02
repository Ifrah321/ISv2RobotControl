namespace Inventory_system.Models;

public abstract class Item
{
    public string Name { get; init; }
    public decimal PricePerUnit { get; init; }
    public string Unit { get; init; }
    public uint InventoryLocation { get; init; }

    protected Item(string name, decimal pricePerUnit, string unit, uint inventoryLocation)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        Unit = unit;
        InventoryLocation = inventoryLocation;
    }

    public override string ToString() => $"{Name} - {PricePerUnit} kr ({Unit})";
}

public sealed class BulkItem : Item
{
    public BulkItem(string name, decimal pricePerUnit, string unit, uint inventoryLocation)
        : base(name, pricePerUnit, unit, inventoryLocation) { }
}

public sealed class UnitItem : Item
{
    public UnitItem(string name, decimal pricePerUnit, uint inventoryLocation)
        : base(name, pricePerUnit, "pcs", inventoryLocation) { }
}