

using Restaurant_Manager.Entity;
using Restaurant_Manager.Services;
using Restaurant_Manager.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RestaurantManager.Helpers;

public class UserViewModel : BaseViewModel
{
    private readonly IUserService _userService;

    public ObservableCollection<User> Users { get; set; } = new();

    public ICommand LoadUsersCommand { get; }

    public UserViewModel(IUserService userService)
    {
        _userService = userService;
        LoadUsersCommand = new RelayCommand(async _ => await LoadUsers());
    }

    private async Task LoadUsers()
    {
        Users.Clear();

    }
}
