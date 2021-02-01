using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.ViewModels.CoffeeShop
{
    public class ShopViewModel
    {
        public List<Item> Items { get; set; }

        public int CurrentUserID { get; set; }

        public double Funds { get; set; }


    }
}
