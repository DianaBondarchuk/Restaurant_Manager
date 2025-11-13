using Restaurant_Manager.Services;
using RestaurantManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Restaurant_Manager.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        
        private readonly IUserService _userService;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        AppDbContext _context;
        public LoginView(AppDbContext context)
        {
            InitializeComponent();
            _context = context;  
            _userService = new UserService(_context);
            LoginBox.Text = "user";
            PasswordBox.Password = "user";
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Login();
        }
        private async Task Login()
        {
            Username = LoginBox.Text;
            Password = PasswordBox.Password;
            //MessageBox.Show(Username + " " + Password);
            var user = await _userService.AuthenticateAsync(Username, Password);
            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Name}!");
                this.Hide();    
            }
            else
            {
                MessageBox.Show("Invalid credentials.");
            }
        }

      
    }
}
