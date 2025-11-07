using System.Linq;
using System.Windows;
using System.Windows.Input;
using Restaurant_Manager.Services;

//namespace Restaurant_Manager.ViewModels
//{
//    public class LoginViewModel : BaseViewModel
//    {
//        private string _username = string.Empty;
//        public string Username
//        {
//            get => _username;
//            set
//            {
//                _username = value;
//                OnPropertyChanged();
//            }
//        }

//        public ICommand LoginCommand { get; }

//        public LoginViewModel()
//        {
//            LoginCommand = new RelayCommand<object>(Login);
//        }

//        private void Login(object parameter)
//        {

//            string password = parameter as string ?? string.Empty;

//            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(password))
//            {
//                MessageBox.Show("Please enter username and password.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
//                return;
//            }

//            using (var context = new AppDbContext())
//            {
//                var user = context.Users.FirstOrDefault(u => u.Username == Username && u.Password == password);

//                if (user != null)
//                {

//                    SessionManager.CurrentUser = user;

//                    MessageBox.Show($"Welcome, {user.Username}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


//                    var mainWindow = new MenuWindow();
//                    Application.Current.MainWindow.Close();
//                    Application.Current.MainWindow = mainWindow;
//                    mainWindow.Show();
//                }
//                else
//                {
//                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
//                }
//            }
//        }
//    }
//}
//using Restaurant_Manager.Services;
using Restaurant_Manager.ViewModels;
using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Input;

public class LoginViewModel : BaseViewModel
{
    private readonly IUserService _userService;

    public string Username { get; set; } = "";
    public string Password { get; set; } = "";

    public ICommand LoginCommand { get; }

    public LoginViewModel(IUserService userService)
    {
        _userService = userService;
        LoginCommand = new RelayCommand(async _ => await Login());
    }

    private async Task Login()
    {
        var user = await _userService.AuthenticateAsync(Username, Password);
        if (user != null)
        {
            MessageBox.Show($"Welcome, {user.Name}!");
            // TODO: Navigate to main window
        }
        else
        {
            MessageBox.Show("Invalid credentials.");
        }
    }

    
}
