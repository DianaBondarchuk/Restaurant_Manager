using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant_Manager.Entity;

namespace Restaurant_Manager.Services
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem> GetByIdAsync(int id);
        Task AddAsync(MenuItem item);
        Task UpdateAsync(MenuItem item);
        Task DeleteAsync(int id);
        void Add(MenuItem newItem);
        IEnumerable<MenuItem> GetAll();
        void Update(MenuItem selectedItem);
        void Delete(int id);
    }
}

