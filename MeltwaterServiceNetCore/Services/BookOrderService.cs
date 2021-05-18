using MeltwaterServiceNetCore;
using MeltwaterServiceNetCore.Entities;
using MeltwaterServiceNetCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeltwaterServiceNetCore.Services
{
    public  class BookOrderService : IBookOrderService
    {
        protected ApplicationDbContext Context { get; }

        public BookOrderService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<long> AddOrder(long customerId, List<long> bookIds)
        {
            var result = await Context.Orders.AddAsync(new Order
            {
                CustomerId = customerId
            });

            result.Entity.Books = new List<Book>();
            foreach (var item in bookIds)
            {
                result.Entity.Books.Add(new Book { BookId = item, });
            }

            await Context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<bool> DeleteOrder(long? orderId)
        {
            var deletable = await Context.Orders.SingleOrDefaultAsync(f => f.Id.Equals(orderId));
            if (deletable != null)
            {

                Context.Orders.Remove(deletable);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Order>> GetOrders(long customerId)
        {
            var result = await Context.Orders.Where(x=>x.CustomerId.Equals(customerId)).Include(z=>z.Books).ToListAsync();
            return result;
        }
    }
}
