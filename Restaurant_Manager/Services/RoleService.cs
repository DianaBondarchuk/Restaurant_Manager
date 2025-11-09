using Microsoft.EntityFrameworkCore;
using Restaurant_Manager;
using Restaurant_Manager.Entity;
using Restaurant_Manager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RoleService : IRoleService
{
    private readonly AppDbContext _context;

    public RoleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetAllRolesAsync() =>
        await _context.Roles.ToListAsync();
}