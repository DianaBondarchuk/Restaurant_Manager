using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public object Role { get; internal set; }
        public object FirstName { get; internal set; }
        public object LastName { get; internal set; }
        public object Username { get; internal set; }
        public bool IsActive { get; internal set; }
        public string? PasswordHash { get; internal set; }

        //public Role? Role { get; set; }
    }
}
