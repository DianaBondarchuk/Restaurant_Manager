using Restaurant_Manager.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Restaurant_Manager.Services
{ 
public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task AddAsync(Order order);
    Task UpdateStatusAsync(int orderId, string status);
}
}