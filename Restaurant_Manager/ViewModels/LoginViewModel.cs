using System.Linq;
using System.Windows;
using System.Windows.Input;
using Restaurant_Manager.Services;

namespace Restaurant_Manager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<object>(Login);
        }

        private void Login(object parameter)
        {
            
            string password = parameter as string ?? string.Empty;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == Username && u.Password == password);

                if (user != null)
                {
                    
                    SessionManager.CurrentUser = user;

                    MessageBox.Show($"Welcome, {user.Username}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    
                    var mainWindow = new MenuWindow();
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = mainWindow;
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

