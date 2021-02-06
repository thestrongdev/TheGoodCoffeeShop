using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Services
{
    public class CoffeeShop : IOldUser
    {
        public OldUser theOldUser { get; } = new OldUser();
    }
}
