using Restaurant_Manager.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant_Manager.ViewModels;
namespace Restaurant_Manager.Services
{
    public interface IMenuItemService
    {
        Task<List<MenuItem>> GetAllAsync();
        Task AddAsync(MenuItem item);
        Task UpdateAsync(MenuItem item);
        Task DeleteAsync(int id);
        Task AddAsync(System.Windows.Controls.MenuItem newItem);
    }
}


