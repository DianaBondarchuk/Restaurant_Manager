
using Microsoft.EntityFrameworkCore;
using Restaurant_Manager;
using Restaurant_Manager.Entity;
using Restaurant_Manager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MenuItemService : IMenuItemService
{
    private readonly AppDbContext _context;

    public MenuItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MenuItem>> GetAllAsync()
    {
        return await _context.MenuItems.ToListAsync();
    }

    public async Task<MenuItem> GetByIdAsync(int id)
    {
        return await _context.MenuItems.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task AddAsync(MenuItem item)
    {
        await _context.MenuItems.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MenuItem item)
    {
        _context.MenuItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var itemToDelete = await GetByIdAsync(id);
        if (itemToDelete != null)
        {
            _context.MenuItems.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }
    }

    //public void Add(MenuItem newItem)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public IEnumerable<MenuItem> GetAll()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void Update(MenuItem selectedItem)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void Delete(int id)
    //{
    //    throw new System.NotImplementedException();
    //}

    //Task<List<MenuItem>> IMenuItemService.GetAllAsync()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public Task AddAsync(System.Windows.Controls.MenuItem newItem)
    //{
    //    throw new System.NotImplementedException();
    //}
}

