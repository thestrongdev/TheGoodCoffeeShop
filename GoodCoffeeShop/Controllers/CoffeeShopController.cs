using GoodCoffeeShop.DALModels;
using GoodCoffeeShop.Models.CoffeeShop;
using GoodCoffeeShop.Services;
using GoodCoffeeShop.ViewModels.CoffeeShop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Controllers
{
    [Authorize]
    public class CoffeeShopController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOldUser _oldUser;
        private readonly ShopDBContext _shopDBContext;

        public CoffeeShopController(IOldUser oldUser, 
            ShopDBContext shopDBContext,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _oldUser = oldUser;
            _shopDBContext = shopDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUserForm() //Register Action for lab 23
        {
            return View();
        }
        public IActionResult FormResult(AddUserFormViewModel model) //MakeNewUser action for lab 23
        {
            var viewModel = new FormResultViewModel();
            var isDouble = double.TryParse(model.Funds, out double actualFunds);
            var oldUser = new OldUsersDAL();

            oldUser.FirstName = model.FirstName;
            oldUser.LastName = model.LastName;
            oldUser.Email = model.Email;
            oldUser.PhoneNum = model.PhoneNum;
            oldUser.Password = model.Password;
            oldUser.PasswordConfirmation = model.PasswordConfirmation;
            oldUser.UserName = $"{oldUser.FirstName.ToLower()}{oldUser.LastName.ToLower()}{oldUser.PhoneNum.Substring(6, 4)}";
            oldUser.Funds = actualFunds;

            //var userTest = new User(); //MAP FOR INDIVIDUAL USER INFO IN MODEL
            _oldUser.theOldUser.FirstName = oldUser.FirstName;
            _oldUser.theOldUser.LastName = oldUser.LastName;
            _oldUser.theOldUser.Email = oldUser.Email;
            _oldUser.theOldUser.PhoneNum = oldUser.PhoneNum;
            _oldUser.theOldUser.Password = oldUser.Password;
            _oldUser.theOldUser.PasswordConfirmation = oldUser.PasswordConfirmation;
            _oldUser.theOldUser.Funds = actualFunds;
            _oldUser.theOldUser.OldUserId = oldUser.OldUserId;

            viewModel.theOldUser = _oldUser.theOldUser;

            if (Validation.ValidateNames(viewModel.theOldUser) &&
              Validation.ValidateEmail(viewModel.theOldUser) &&
              Validation.ValidatePhoneNumber(viewModel.theOldUser) &&
              Validation.ValidatePW(viewModel.theOldUser) && isDouble) 
            {
                _shopDBContext.OldUsers.Add(oldUser);
                _shopDBContext.SaveChanges();

                var oldUsers = _shopDBContext.OldUsers.ToList();

                //MAP UsersDAL to FormResultsView
                var usersViewModelList = oldUsers
                    .Select(usersDal => new OldUser()
                    {
                        FirstName = usersDal.FirstName,
                        LastName = usersDal.LastName,
                        Email = usersDal.Email,
                        Password = usersDal.Password,
                        PasswordConfirmation = usersDal.PasswordConfirmation,
                        OldUserId = usersDal.OldUserId
                    }).ToList();

                viewModel.OldUsers = usersViewModelList;

                return View("FormResult", viewModel);
            }
            else
            {
                return View("AddUserForm", model);
            }
      
        }

        public IActionResult LogIn()
        {
            return View();
        }
             
        

        //    //GetUserWhereIDIsFirst(viewModel.CurrentUserID);

        //    //_user.theUser.UserID = viewModel.CurrentUserID;
        //    //_user.theUser.Funds = viewModel.Funds;


        public IActionResult Shop(LogInViewModel model) //Register Action for lab 23
        {
            
            var viewModel = new ShopViewModel();

            foreach (var oldUser in _shopDBContext.OldUsers.ToList())
            {
                if (oldUser.UserName == model.UserName && oldUser.Password == model.Password)
                {
                    model.CurrentUserID = oldUser.OldUserId;
                    model.Funds = oldUser.Funds;

                }
            }

            viewModel.CurrentUserID = model.CurrentUserID;
            viewModel.Funds = model.Funds;

            var items = _shopDBContext.Items.ToList();

            viewModel.Items = items
                .Select(itemsDal => new Item()
                {
                    ItemID = itemsDal.ItemID,
                    Name = itemsDal.Name,
                    Description = itemsDal.Description,
                    Quantity = itemsDal.Quantity,
                    Price = itemsDal.Price
                }).ToList();

            if (viewModel.CurrentUserID != 0)
            {
                return View(viewModel);
            }

            else
            {
                return View("LogIn", model);
            }
        }

        public IActionResult BuyResult(int userID, int ID, double funds) //ID for item
        {
            var viewModel = new BuyResultViewModel();
            viewModel.Funds = funds;
            viewModel.CurrentUserID = userID;

            double price = 0;

            foreach (var item in _shopDBContext.Items.ToList())
            {
                if (item.ItemID == ID)
                {
                    price = item.Price;
                }
            }

            bool userInDB = false;
            bool enoughCash = false;

            foreach (var oldUser in _shopDBContext.OldUsers.ToList())
            {
                if (oldUser.OldUserId == viewModel.CurrentUserID)
                {
                    userInDB = true;

                    if (oldUser.Funds > price)
                    {
                        enoughCash = true;
                        oldUser.Funds = oldUser.Funds - price;
                        _shopDBContext.SaveChanges();
                        viewModel.Funds = oldUser.Funds;
                    }
                }
            }

            var errorModel = new ErrorPageViewModel();
            errorModel.UserFunds = viewModel.Funds;

            if (userInDB && enoughCash)
            {
                return View("Shop", viewModel);
            }
            else
            {
                return View("ErrorPage", errorModel);
            }

          }


        public IActionResult ErrorPage(ShopViewModel model)
        {
            var viewModel = new ErrorPageViewModel();
            viewModel.UserFunds = model.Funds;

            return View();
        }



            private OldUser GetUserWhereIDIsFirst(int id)
        {
            OldUsersDAL userDAL = _shopDBContext.OldUsers
                .Where(oldUser => oldUser.OldUserId == id).FirstOrDefault();


            var oldUser = new OldUser();
            oldUser.OldUserId = userDAL.OldUserId;
            oldUser.Funds = userDAL.Funds;
            return oldUser;
        }

    }
}
