using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Restaurant_Manager.Entity;
using Restaurant_Manager.Services;

namespace Restaurant_Manager
{
    internal class MenuViewModel : INotifyPropertyChanged
    {
        private readonly IMenuItemService _menuService;

        private ObservableCollection<MenuItem> _menuItems;
        public ObservableCollection<MenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        private MenuItem _selectedItem;
        public MenuItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public MenuViewModel(IMenuItemService menuService)
        {
            _menuService = menuService;
            LoadMenu();

            AddCommand = new RelayCommand(AddItem);
            EditCommand = new RelayCommand(EditItem, () => SelectedItem != null);
            DeleteCommand = new RelayCommand(DeleteItem, () => SelectedItem != null);
        }

        private void LoadMenu()
        {
            MenuItems = new ObservableCollection<MenuItem>(_menuService.GetAll());
        }

        private void AddItem()
        {
            var newItem = new MenuItem { Name = "New Dish", Price = 0 };
            _menuService.Add(newItem);
            LoadMenu();
        }

        private void EditItem()
        {
            if (SelectedItem != null)
            {
                _menuService.Update(SelectedItem);
                LoadMenu();
            }
        }

        private void DeleteItem()
        {
            if (SelectedItem != null)
            {
                _menuService.Delete(SelectedItem.Id);
                LoadMenu();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
