﻿using GoodCoffeeShop.ViewModels.CoffeeShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Services
{
    public class UserItems : IUserItems
    {
        public List<Item> userPurchases { get; } = new List<Item>();

    }
}
