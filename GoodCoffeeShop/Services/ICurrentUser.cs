using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Services
{
    public interface ICurrentUser
    {
        public User theUser { get; }
        public bool loggedIn { get; set; }
    }
}
