using GoodCoffeeShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.ViewModels.CoffeeShop
{
    public class LogInViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool UserLoggedIn { get; set; }

        public int CurrentUserID { get; set; }

        public double Funds { get; set; }

        //public User CurrentUser { get; } = new User();


    }
}
