//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Restaurant_Manager.ViewModels
//{
//    internal class OrderViewModel
//    {
//    }
//}
using Restaurant_Manager.Entity;

using Restaurant_Manager.Services;
using Restaurant_Manager.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

public class OrderViewModel : BaseViewModel
{
    private readonly IOrderService _orderService;

    public ObservableCollection<Order> Orders { get; set; } = new();

    public ICommand LoadOrdersCommand { get; }

    public OrderViewModel(IOrderService orderService)
    {
        _orderService = orderService;
        LoadOrdersCommand = new RelayCommand(async _ => await LoadOrders());
    }

    private async Task LoadOrders()
    {
        Orders.Clear();
        var orders = await _orderService.GetAllAsync();
        foreach (var order in orders) Orders.Add(order);
    }
}