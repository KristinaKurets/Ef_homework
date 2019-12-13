using EfLesson1.Interfaces;
using EfLesson1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfLesson1.Services
{
    public class ShopService : IShopService
    {
        public async Task CreateShopAsync(Shop shop)
        {
            using (var context = new ShopContext())
            {
                context.Shops.Add(shop);
                await context.SaveChangesAsync();
            }
        }

        public Task<Shop> GetShopByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Shop>> GetShopsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Shop>> PunchDexterAsync()
        {
            throw new NotImplementedException();
        }
    }
}
