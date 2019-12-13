using EfLesson1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfLesson1.Interfaces
{
    public interface IShopService
    {
        Task<List<Shop>> GetShopsAsync();

        Task<Shop> GetShopByIdAsync(int id);

        Task CreateShopAsync(Shop shop);

    }
}
