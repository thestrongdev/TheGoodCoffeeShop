using GoodCoffeeShop.DALModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Services
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UsersDAL> Users { get; set; }
        public DbSet<ItemsDAL> Items { get; set; }
    }
}
