
using Microsoft.EntityFrameworkCore;
using Restaurant_Manager;
using Restaurant_Manager.Entity;
using Restaurant_Manager.Services;
using System.Threading.Tasks;
using System.Windows;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public Task<User?> AuthenticateAsync(string login, string password)
    {
        return _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Login == login && u.Password == password && u.IsActive);
    }
}
