using GoodCoffeeShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Models.CoffeeShop
{
    public class FormResultViewModel
    {
        public OldUser theOldUser { get; set; }
        public List<OldUser> OldUsers { get; set; }
    }
}
