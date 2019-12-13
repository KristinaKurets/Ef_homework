using System;
using System.Collections.Generic;
using EfLesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace EfLesson1
{
    public class ShopContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-IAGJLVQ\SQLEXPRESS;Database=ShoeShopHW;Integrated Security=True;");
        }
    }
}
