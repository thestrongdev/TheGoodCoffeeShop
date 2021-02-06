using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Controllers
{
    [Authorize]
    public class UserItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
