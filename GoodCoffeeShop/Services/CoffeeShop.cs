using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Services
{
    public class CoffeeShop : IUser
    {
        public User theUser { get; } = new User();
    }
}
