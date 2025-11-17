using Restaurant_Manager;
using Restaurant_Manager.Services;
using Restaurant_Manager.Views;
using RestaurantManager.Helpers;
//using RestaurantManager.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RestaurantManager
{
    public partial class MainWindow : Window
    {
        //private NavigationService _navigationService;

        //public DependencyObject MainContent { get; }
        //RelayCommand command;
        private readonly AppDbContext _context;
        private readonly UserService _userService;
        MenuViewModel menuViewModel;
        IMenuItemService menuService;
        public MainWindow()
        {
            InitializeComponent();

            _context = new AppDbContext();

            LoginView login = new LoginView(_context);
            login.ShowDialog();

            _menuService = new MenuItemService(_context);
            _orderService = new OrderService(_context);
            _userService = new UserService(_context);

            _menuViewModel = new MenuViewModel(_menuService);
            _orderViewModel = new OrderViewModel(_orderService);
            _userViewModel = new UserViewModel(_userService);
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Відкрито розділ 'Замовлення'");

            await _orderViewModel.LoadOrders();

            var window = new OrderView
            {
                DataContext = _orderViewModel
            };

            window.Show();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {;
            MessageBox.Show("Відкрито розділ 'Меню'");

            await _menuViewModel.LoadItems();

            var window = new MenuView
            {
                DataContext = _menuViewModel
            };
            window.Show();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await _userViewModel.LoadUsers();
            var window = new UserView
            {
                DataContext = _userViewModel
            };

            window.Show();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }
    }
}