using EfLesson1.Interfaces;
using EfLesson1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfLesson1.Services
{
    public class ShopUi : IShopUi
    {
        public Shop CreateShop()
        {
            using (var context = new ShopContext())
            {
                var shop = new Shop();
                Console.WriteLine("Choose the address:");
                foreach (var address in context.Addresses)
                {
                    Console.WriteLine($"{address.Id} - {address.City}, {address.Street}, {address.HouseNumber}");
                }
                var selectedAddress = context.Addresses.FirstOrDefault(x => x.Id == int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the name of shop:");
                shop.ShopName = Console.ReadLine();
                shop.Address = selectedAddress;
                return shop;
            }
                
        }
    }
}
