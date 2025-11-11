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
        private NavigationService _navigationService;

        public object MainContent { get; }

        public MainWindow()
        {
            InitializeComponent();

            // Ініціалізація NavigationService з ContentControl
            _navigationService = new NavigationService(MainContent);

            // Встановлюємо стартовий екран (LoginView)
            _navigationService.Navigate(new LoginView());
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        // Метод для навігації з ViewModel (опціонально)
        public void NavigateTo(UserControl view)
        {
            _navigationService.Navigate(view);
        }
    }
}