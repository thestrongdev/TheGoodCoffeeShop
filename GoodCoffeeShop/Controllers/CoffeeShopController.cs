using GoodCoffeeShop.DALModels;
using GoodCoffeeShop.Models.CoffeeShop;
using GoodCoffeeShop.Services;
using GoodCoffeeShop.ViewModels.CoffeeShop;
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
        private readonly ShopDBContext _shopDBContext;

        public CoffeeShopController(IUser user, ShopDBContext shopDBContext)
        {
            _user = user;
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
            var user = new UsersDAL();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNum = model.PhoneNum;
            user.Password = model.Password;
            user.PasswordConfirmation = model.PasswordConfirmation;
            user.UserName = $"{user.FirstName.ToLower()}{user.LastName.ToLower()}{user.PhoneNum.Substring(6, 4)}";
            user.Funds = actualFunds;

            //var userTest = new User(); //MAP FOR INDIVIDUAL USER INFO IN MODEL
            _user.theUser.FirstName = user.FirstName;
            _user.theUser.LastName = user.LastName;
            _user.theUser.Email = user.Email;
            _user.theUser.PhoneNum = user.PhoneNum;
            _user.theUser.Password = user.Password;
            _user.theUser.PasswordConfirmation = user.PasswordConfirmation;
            _user.theUser.Funds = actualFunds;
            _user.theUser.UserID = user.UserID;

            viewModel.theUser = _user.theUser;

            if (Validation.ValidateNames(viewModel.theUser) &&
              Validation.ValidateEmail(viewModel.theUser) &&
              Validation.ValidatePhoneNumber(viewModel.theUser) &&
              Validation.ValidatePW(viewModel.theUser) && isDouble) 
            {
                _shopDBContext.Users.Add(user);
                _shopDBContext.SaveChanges();

                var users = _shopDBContext.Users.ToList();

                //MAP UsersDAL to FormResultsView
                var usersViewModelList = users
                    .Select(usersDal => new User()
                    {
                        FirstName = usersDal.FirstName,
                        LastName = usersDal.LastName,
                        Email = usersDal.Email,
                        Password = usersDal.Password,
                        PasswordConfirmation = usersDal.PasswordConfirmation,
                        UserID = usersDal.UserID
                    }).ToList();

                viewModel.Users = usersViewModelList;

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

            foreach (var user in _shopDBContext.Users.ToList())
            {
                if (user.UserName == model.UserName && user.Password == model.Password)
                {
                    model.CurrentUserID = user.UserID;
                    model.Funds = user.Funds;

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

            foreach (var user in _shopDBContext.Users.ToList())
            {
                if (user.UserID == viewModel.CurrentUserID)
                {
                    userInDB = true;

                    if (user.Funds > price)
                    {
                        enoughCash = true;
                        user.Funds = user.Funds - price;
                        _shopDBContext.SaveChanges();
                        viewModel.Funds = user.Funds;
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



            private User GetUserWhereIDIsFirst(int id)
        {
            UsersDAL userDAL = _shopDBContext.Users
                .Where(user => user.UserID == id).FirstOrDefault();


            var user = new User();
            user.UserID = userDAL.UserID;
            user.Funds = userDAL.Funds;
            return user;
        }

    }
}
