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
        private readonly AppDbContext _context;

        // Сервіси
        private readonly UserService _userService;
        private IMenuItemService _menuService;
        private IOrderService _orderService;

        // ViewModel-и
        private MenuViewModel _menuViewModel;
        private OrderViewModel _orderViewModel;
        private UserViewModel _userViewModel;
        public MainWindow()
        {
            InitializeComponent();

            _context = new AppDbContext();

            var login = new LoginView(_context);
            login.ShowDialog();

            _menuService = new MenuItemService(_context);
            _orderService = new OrderService(_context);
            _userService = new UserService(_context);

            _menuViewModel = new MenuViewModel(_menuService);
            _orderViewModel = new OrderViewModel(_orderService);
            _userViewModel = new UserViewModel(_userService);   

        }

        //private readonly IUserService _userService;

        //public MainWindow()
        //{
        //    InitializeComponent();
        //    _context = new AppDbContext();
        //    _userService = new UserService(_context);
        //}




        private void Button_Click(object sender, RoutedEventArgs e)
        {


            MessageBox.Show("Відкрито розділ 'Замовлення'");
            _orderViewModel.LoadOrdersCommand.Execute(null);

            var window = new OrderView
            {
                DataContext = _orderViewModel
            };
            window.Show();


        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Відкрито розділ 'Меню'");
            await _menuViewModel.LoadItems();

            var window = new MenuView
            {
                DataContext = _menuViewModel
            };
            window.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Відкрито розділ 'Користувачі'");
            _userViewModel.LoadUsersCommand.Execute(null);

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