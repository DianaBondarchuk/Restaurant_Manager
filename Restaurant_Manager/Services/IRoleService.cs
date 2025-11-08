using Restaurant_Manager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();
    }
}
