using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.ViewModels.CoffeeShop
{
    public class UserPurchasesViewModel
    {
        public List<Item> userPurchases { get; set; }

        public int CurrentUserID { get; set; }
    }
}
