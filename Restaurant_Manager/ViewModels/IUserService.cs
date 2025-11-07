using Restaurant_Manager.Entity;
using System.Threading.Tasks;

namespace Restaurant_Manager.ViewModel
{
    internal interface IUserService
    {
        Task<User?> GetUserByCredentialsAsync(string username, string pwd);
    }
}