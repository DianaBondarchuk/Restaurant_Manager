using System.Linq;
using System.Windows;
using System.Windows.Input;
using Restaurant_Manager.Services;
using Restaurant_Manager.Commands;
using Restaurant_Manager.ViewModels;
using System.Threading.Tasks;

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
        }
        else
        {
            MessageBox.Show("Invalid credentials.");
        }
    }

    
}
