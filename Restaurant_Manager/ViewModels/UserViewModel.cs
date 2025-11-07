//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Restaurant_Manager.ViewModels
//{
//    internal class UserViewModel
//    {
//    }
//}
using Restaurant_Manager.Entity;

using Restaurant_Manager.Services;
using Restaurant_Manager.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

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
        // TODO: Add method in IUserService to get all users
    }
}
