using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_system.Models;

namespace Inventory_system;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Order> QueuedOrders { get; } = new();
    public ObservableCollection<Order> ProcessedOrders { get; } = new();
    public ObservableCollection<string> StatusMessages { get; } = new();

    private decimal _totalRevenue;
    public decimal TotalRevenue
    {
        get => _totalRevenue;
        set { _totalRevenue = value; OnPropertyChanged(nameof(TotalRevenue)); }
    }

    private readonly ItemSorterRobot _robot = new();
    public ICommand ProcessNextOrderCommand { get; }

    public MainViewModel()
    {
        ProcessNextOrderCommand = new RelayCommand(async () => await ProcessNextOrder());
        SeedTestOrders();
    }

    private async Task ProcessNextOrder()
    {
        if (QueuedOrders.Count == 0)
        {
            StatusMessages.Add($"{TimeStamp()} No queued orders.");
            return;
        }

        var order = QueuedOrders[0];
        QueuedOrders.RemoveAt(0);

        StatusMessages.Add($"{TimeStamp()} Processing {order.Customer.Name}");

        foreach (var line in order.OrderLines)
        {
            for (int i = 0; i < line.Quantity; i++)
            {
                StatusMessages.Add($"{TimeStamp()} Picking {line.Item.Name} (slot {line.Item.InventoryLocation})");
                _robot.PickUp(line.Item.InventoryLocation);
                await Task.Delay(1500);
            }
        }

        TotalRevenue += 500m;
        ProcessedOrders.Add(order);
        StatusMessages.Add($"{TimeStamp()} Order complete");
    }

    private string TimeStamp() => DateTime.Now.ToString("HH.mm.ss");

    private void SeedTestOrders()
    {
        var item1 = new UnitItem("M3 screw", 500m, 1);
        var item2 = new UnitItem("M3 nut", 500m, 2);
        var item3 = new UnitItem("Pen", 500m, 3);

        QueuedOrders.Add(new Order(new Customer("Vare 1"))
        {
            OrderLines = { new OrderLine(item1, 1), new OrderLine(item2, 2), new OrderLine(item3, 1) }
        });

        QueuedOrders.Add(new Order(new Customer("Vare 2"))
        {
            OrderLines = { new OrderLine(item2, 1) }
        });

        QueuedOrders.Add(new Order(new Customer("Vare 3"))
        {
            OrderLines = { new OrderLine(item1, 1) }
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string n) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
}
