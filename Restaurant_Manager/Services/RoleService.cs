//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Restaurant_Manager.Entity;


//namespace Restaurant_Manager.Services
//{
//    internal class RoleService
//    {
//        private readonly AppDbContext _context;

//        public RoleService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Role> CreateRoleAsync(Role role)
//        {
//            _context.Roles.Add(role);
//            await _context.SaveChangesAsync();
//            return role;
//        }

//        public async Task<List<Role>> GetAllRolesAsync()
//        {
//            return await _context.Roles.ToListAsync();
//        }

//        public async Task<Role?> GetRoleByIdAsync(int id)
//        {
//            return await _context.Roles.FindAsync(id);
//        }

//        public async Task<bool> UpdateRoleAsync(Role roleToUpdate)
//        {
//            var existingRole = await _context.Roles.FindAsync(roleToUpdate.Id);

//            if (existingRole == null)
//            {
//                return false;
//            }

//            existingRole.Name = roleToUpdate.Name;

//            try
//            {
//                _context.Roles.Update(existingRole);
//                await _context.SaveChangesAsync();
//                return true;
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                return false;
//            }
//        }
//        public async Task<bool> DeleteRoleAsync(int id, int? newRoleId = null)
//        {
//            var role = await _context.Roles.FindAsync(id);

//            if (role == null)
//            {
//                return false;
//            }

//            var usersWithOldRole = await _context.Users
//                .Where(u => u.RoleId == id)
//                .ToListAsync();

//            if (usersWithOldRole.Any())
//            {
//                if (!newRoleId.HasValue || await _context.Roles.FindAsync(newRoleId.Value) == null)
//                {
//                    throw new InvalidOperationException("Неможливо видалити роль, оскільки до неї прив'язані користувачі. Вкажіть ID нової ролі для цих користувачів.");
//                }

//                foreach (var user in usersWithOldRole)
//                {
//                    user.RoleId = newRoleId.Value;
//                }
//                _context.Users.UpdateRange(usersWithOldRole);
//            }

//            _context.Roles.Remove(role);
//            await _context.SaveChangesAsync();
//            return true;
//        }
//    }
//}
using Microsoft.EntityFrameworkCore;
using Restaurant_Manager;
using Restaurant_Manager.Entity;
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