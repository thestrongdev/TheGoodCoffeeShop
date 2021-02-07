﻿using GoodCoffeeShop.ViewModels.CoffeeShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Services
{
    public class CoffeeShop : ICurrentUser
    {
        public User theUser { get; } = new User();
        public bool loggedIn { get; set ; }

    }
}
