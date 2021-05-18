using MeltwaterServiceNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeltwaterServiceNetCore.Services.Interfaces
{
    public interface IBookOrderService
    {
        Task<IEnumerable<Order>> GetOrders(long customerId);
        Task<long> AddOrder(long customerId, List<long> bookIds);
        Task<bool> DeleteOrder(long? orderId);
    }
}
