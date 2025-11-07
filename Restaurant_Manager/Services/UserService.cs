using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_Manager.Entity;


namespace Restaurant_Manager.Services
{
    internal class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

       
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                                 .Include(u => u.Role) 
                                 .Where(u => u.IsActive) 
                                 .ToListAsync();
        }

        
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                                 .Include(u => u.Role)
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateUserAsync(User userToUpdate)
        {
            var existingUser = await _context.Users.FindAsync(userToUpdate.Id);

            if (existingUser == null)
            {
                return false; 
            }

            
            //existingUser.FirstName = userToUpdate.FirstName;
            existingUser.LastName = userToUpdate.LastName;
           // existingUser.Username = userToUpdate.Username;
            existingUser.RoleId = userToUpdate.RoleId;
            existingUser.IsActive = userToUpdate.IsActive;

           
            if (!string.IsNullOrEmpty(userToUpdate.PasswordHash))
            {
                existingUser.PasswordHash = userToUpdate.PasswordHash;
            }

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

       
        public async Task<bool> DeleteUserAsync(int id, bool softDelete = true)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            if (softDelete)
            {               
                user.IsActive = false;
                _context.Users.Update(user);
            }
            else
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
