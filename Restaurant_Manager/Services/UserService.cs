
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_Manager.Entity;
using Restaurant_Manager;
using Restaurant_Manager.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(string login, string password)
    {
        return await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Login == login && u.Password == password && u.IsActive);
    }
}
