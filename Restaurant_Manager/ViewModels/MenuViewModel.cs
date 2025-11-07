//using System.Collections.ObjectModel;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using Restaurant_Manager.Entity;
//using Restaurant_Manager.Services;

//namespace Restaurant_Manager.ViewModels
//{
//    public class MenuViewModel
//    {
//        private readonly IMenuItemService _menuItemService;

//        public ObservableCollection<MenuItem> MenuItems { get; set; }
//        public MenuItem SelectedItem { get; set; }

//        public ICommand AddCommand { get; }
//        public ICommand UpdateCommand { get; }
//        public ICommand DeleteCommand { get; }
//        public ICommand LoadCommand { get; }

//        public MenuViewModel(IMenuItemService menuItemService)
//        {
//            _menuItemService = menuItemService;
//            MenuItems = new ObservableCollection<MenuItem>();

//            AddCommand = new RelayCommand(async _ => await AddItem());
//            UpdateCommand = new RelayCommand(async _ => await UpdateItem(), _ => SelectedItem != null);
//            DeleteCommand = new RelayCommand(async _ => await DeleteItem(), _ => SelectedItem != null);
//            LoadCommand = new RelayCommand(async _ => await LoadItems());
//        }

//        private async Task LoadItems()
//        {
//            MenuItems.Clear();
//            var items = await _menuItemService.GetAllAsync();
//            foreach (var item in items)
//                MenuItems.Add(item);
//        }

//        private async Task AddItem()
//        {
//            var newItem = new MenuItem
//            {
//                Name = "New Dish",
//                Description = "Description",
//                Price = 0
//            };

//            await _menuItemService.AddAsync(newItem);
//            await LoadItems();
//        }

//        private async Task UpdateItem()
//        {
//            if (SelectedItem != null)
//            {
//                await _menuItemService.UpdateAsync(SelectedItem);
//                await LoadItems();
//            }
//        }

//        private async Task DeleteItem()
//        {
//            if (SelectedItem != null)
//            {
//                await _menuItemService.DeleteAsync(SelectedItem.Id);
//                await LoadItems();
//            }
//        }
//    }
//}
using Restaurant_Manager;
//using Restaurant_Manager.Models;
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