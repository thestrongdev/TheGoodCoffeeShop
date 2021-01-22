using GoodCoffeeShop.Models.CoffeeShop;
using GoodCoffeeShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Controllers
{
    public class CoffeeShopController : Controller
    {
        private readonly IUser _user;

        public CoffeeShopController(IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUserForm()
        {
            return View();
        }
        public IActionResult FormResult(AddUserFormViewModel model)
        {
            var user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNum = model.PhoneNum;
            user.Password = model.Password;
            user.PasswordConfirmation = model.PasswordConfirmation;

            _user.theUser.FirstName = user.FirstName;
            _user.theUser.LastName = user.LastName;
            _user.theUser.Email = user.Email;
            _user.theUser.PhoneNum = user.PhoneNum;
            _user.theUser.Password = user.Password;
            _user.theUser.PasswordConfirmation = user.PasswordConfirmation;

            var viewModel = new FormResultViewModel();
            viewModel.theUser = _user.theUser;

            //return View("FormResult", viewModel);


            if (Validation.ValidateNames(viewModel.theUser) &&
                Validation.ValidateEmail(viewModel.theUser) &&
                Validation.ValidatePhoneNumber(viewModel.theUser) &&
                Validation.ValidatePW(viewModel.theUser))
            {
                return View("FormResult", viewModel);
            }
            else
            {
                return View("AddUserForm", model);
            }
        }

    }
}
