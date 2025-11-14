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

            // Ініціалізація NavigationService з ContentControl
            //_navigationService = new NavigationService(MainContent);
            //_navigationService = new NavigationService(MainContent);

            // Встановлюємо стартовий екран (LoginView)
            //_navigationService.Navigate(new LoginView());
            //command = new RelayCommand((o) => Login());
            _context = new AppDbContext();
            _userService = new UserService(_context);
            LoginView login =new LoginView( _context); 
            login.ShowDialog();
            menuService = new MenuItemService(_context);
            menuViewModel = new MenuViewModel(menuService);    
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
            menuViewModel.LoadItems();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Додано новий елемент меню");
            menuViewModel.AddItem();



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Відкрито розділ 'Користувачі'"); 

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }
    }
}