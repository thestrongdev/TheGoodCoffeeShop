﻿using GoodCoffeeShop.ViewModels.CoffeeShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Services
{
    public class User 
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNum { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public double Funds { get; set; }

        public string UserName { get; set; }

        public List<Item> UserPurchases { get; set; }
    }
}
