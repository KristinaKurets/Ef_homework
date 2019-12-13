using EfLesson1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using EfLesson1.Interfaces;
using EfLesson1.Services;

namespace EfLesson1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await ManageStock();
            await AddAddress();
            AddShop();
            //AddCustomer();
            AddSeller();

        }

        static async Task ManageStock()
        {
            while (true)
            {
                Console.WriteLine("Do you want to add item?(y/n)");
                string answer = Console.ReadLine();
                if (answer != "y") break;
                Console.WriteLine("Select a shop to add item");
                using (var context = new ShopContext())
                {
                    foreach (var shop in context.Shops)
                    {
                        Console.WriteLine($"{shop.Id} - {shop.ShopName}");
                    }
                    var selectedShop = await context.Shops.Include(x => x.Stock).FirstOrDefaultAsync(x => x.Id == int.Parse(Console.ReadLine()));

                    var item = new ShopItem();
                    Console.WriteLine("enter brand");
                    item.Brand = Console.ReadLine();
                    Console.WriteLine("enter price");
                    item.Price = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter size");
                    item.Size = int.Parse(Console.ReadLine());

                    selectedShop.Stock.Add(item);
                    context.SaveChanges();
                }


            }
        }
        static async Task AddAddress()
        {

            using (var context = new ShopContext())
            {

                while (true)
                {
                    Console.WriteLine("Do you want to add address? Press y/n");
                    string answer = Console.ReadLine();
                    if (answer != "y") break;
                    else
                    {
                        var address = new Address();
                        Console.WriteLine("Enter the city:");
                        address.City = Console.ReadLine();
                        Console.WriteLine("Enter the street:");
                        address.Street = Console.ReadLine();
                        Console.WriteLine("Enter the number of house:");
                        address.HouseNumber = Console.ReadLine();
                        context.Addresses.Add(address);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }

        static async Task AddShop()
        {

            while (true)
            {
                Console.WriteLine("Do you want to add the shop? Press y/n");
                string answer = Console.ReadLine();
                if (answer != "y") break;
                else
                {
                    IShopUi shopUi = new ShopUi();
                    var shop = shopUi.CreateShop();
                    IShopService shopService = new ShopService();
                    await shopService.CreateShopAsync(shop);
                }
            }

        }

        static void AddCustomer()
        {
            using (var context = new ShopContext())
            {
                while (true)
                {
                    Console.WriteLine("Do you want to add the customer? Press y/n");
                    string answer = Console.ReadLine();
                    if (answer != "y") break;
                    else
                    {
                        var customer = new Customer();
                        Console.WriteLine("Enter the name of customer:");
                        customer.Name = Console.ReadLine();
                        Console.WriteLine("Enter the date of his last visit (dd.mm.yyyy):");
                        customer.LastVisit = DateTime.Parse(Console.ReadLine());
                        //у него нет заказов, но как добавить?
                        context.Customers.Add(customer);
                        context.SaveChanges();
                    }
                }
            }
        }

        static void AddSeller()
        {
            using (var context = new ShopContext())
            {
                while (true)
                {
                    Console.WriteLine("Do you want to add the seller? Press y/n");
                    string answer = Console.ReadLine();
                    if (answer != "y") break;
                    else
                    {
                        var seller = new Seller();
                        Console.WriteLine("Choose the shop you want to add the seller:");
                        foreach (var shop in context.Shops.Include(x => x.Address))
                        {
                            //как сделать так, чтобы через айди вызывался нужный адрес и показывался?
                            Console.WriteLine($"{shop.Id } - {shop.ShopName}, {shop.Address.City}, {shop.Address.Street}, {shop.Address.HouseNumber}");
                        }
                        var selectedShop = context.Shops.FirstOrDefault(x => x.Id == int.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter the name of seller:");
                        seller.Name = Console.ReadLine();
                        seller.Shop = selectedShop;
                    }
                }
            }
        }
    }
}
