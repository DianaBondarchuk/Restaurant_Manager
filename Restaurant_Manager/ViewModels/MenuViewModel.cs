
using Restaurant_Manager.Commands;
using Restaurant_Manager.Services;
using Restaurant_Manager.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

public class MenuViewModel : BaseViewModel
{
    private readonly IMenuItemService _menuService;

    public ObservableCollection<MenuItem> MenuItems { get; set; } = new();
    public MenuItem NewItem { get; set; } = new();

    public ICommand LoadCommand { get; }
    public ICommand AddCommand { get; }

    public MenuViewModel(IMenuItemService menuService)
    {
        _menuService = menuService;
        LoadCommand = new RelayCommand(async _ => await LoadItems());
        AddCommand = new RelayCommand(async _ => await AddItem());
    }

    private async Task LoadItems()
    {
        MenuItems.Clear();
        var items = await _menuService.GetAllAsync();
        foreach (var item in items) MenuItems.Add(item);
    }

    private async Task AddItem()
    {
        await _menuService.AddAsync(NewItem);
        await LoadItems();
        NewItem = new MenuItem();
        OnPropertyChanged(nameof(NewItem));
    }
}