using GoodCoffeeShop.DALModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Services
{
    public class ShopDBContext : IdentityDbContext
    {
        public ShopDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<OldUsersDAL> OldUsers { get; set; } //TO BE REMOVED AFTER SETTING UP ASP IDENTITY
        public DbSet<ItemsDAL> Items { get; set; }

        
    }
}
