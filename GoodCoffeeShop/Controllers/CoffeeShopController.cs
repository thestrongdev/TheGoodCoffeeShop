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
        private readonly ICurrentUser _user;
        private readonly ShopDBContext _shopDBContext;
        private readonly IUserItems _userItem;

        public CoffeeShopController(ICurrentUser user, ShopDBContext shopDBContext, IUserItems useritem)
        {
            _user = user;
            _shopDBContext = shopDBContext;
            _userItem = useritem;
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
            var viewModel = new FormResultViewModel();
            var isDouble = double.TryParse(model.Funds, out double actualFunds);
            var user = new UsersDAL();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNum = model.PhoneNum;
            user.Password = model.Password;
            user.PasswordConfirmation = model.PasswordConfirmation;
            user.UserName = model.Email;
            user.Funds = actualFunds;

            viewModel.theUser = new User();
            viewModel.theUser.FirstName = model.FirstName;
            viewModel.theUser.LastName = model.LastName;
            viewModel.theUser.Email = model.Email;
            viewModel.theUser.PhoneNum = model.PhoneNum;
            viewModel.theUser.Password = model.Password;
            viewModel.theUser.Funds = actualFunds;
            viewModel.theUser.UserName = model.Email;
            viewModel.theUser.PasswordConfirmation = model.PasswordConfirmation;
            //var userTest = new User(); //MAP FOR INDIVIDUAL USER INFO IN MODEL
           

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

        public IActionResult LogIn() //LAB 24
        {
            return View();
        }


        public IActionResult GetCurrentUser(LogInViewModel model)
        {
            foreach (var user in _shopDBContext.Users.ToList())
            {
                if (user.UserName == model.UserName && user.Password == model.Password)
                {
                    _user.theUser.UserName = user.UserName;
                    _user.theUser.Password = user.Password;
                    _user.theUser.Email = user.Email;
                    _user.theUser.PhoneNum = user.PhoneNum;
                    _user.theUser.Password = user.Password;
                    _user.theUser.PasswordConfirmation = user.PasswordConfirmation;
                    _user.theUser.Funds = user.Funds;
                    _user.theUser.UserID = user.UserID;
                }
            }

            _user.loggedIn = true;


            return View("SuccessfulLogIn");
        }

        public IActionResult LogOut() //LAB 24
        {
            _user.theUser.UserID = 0;
            _user.theUser.Funds = 0;
            _user.theUser.UserName = null;
            _user.loggedIn = false;
            return View();
        }

        public IActionResult Shop() //Register Action for lab 23
        {

            var viewModel = new ShopViewModel();

            viewModel.CurrentUserID = _user.theUser.UserID;
            viewModel.Funds = _user.theUser.Funds;

            var storeItems = _shopDBContext.Items.ToList();

            var userItems = _shopDBContext.UserItems.Where(userItem => userItem.UserId == _user.theUser.UserID).ToList();

            viewModel.Items = storeItems
                .Select(itemsDal => new Item()
                {
                    ItemID = itemsDal.ItemID,
                    Name = itemsDal.Name,
                    Description = itemsDal.Description,
                    Quantity = itemsDal.Quantity,
                    Price = itemsDal.Price
                }).ToList();


            foreach(var item in viewModel.Items)
            {
                foreach (var useritem in userItems)
                {
                    if (item.ItemID == useritem.ItemId)
                    {
                        item.PurchasedByUser = true;
                    }
                }
            }

            if (_user.theUser.UserID != 0)
            {
                return View(viewModel);
            }

            else
            {

                return View("PleaseLogIn");
            }
        }

        public IActionResult BuyResult(int ID) //ID for item
        {
            var viewModel = new BuyResultViewModel();
            viewModel.Funds = _user.theUser.Funds;
            viewModel.CurrentUserID = _user.theUser.UserID;

            var userItem = new UserItemsDAL();
            userItem.UserId = viewModel.CurrentUserID;
            
            double price = 0;

            foreach (var item in _shopDBContext.Items.ToList())
            {
                if (item.ItemID == ID)
                {
                    price = item.Price;
                    userItem.ItemId = item.ItemID;
                    userItem.Name = item.Name;
                    userItem.Description = item.Description;
                    userItem.Quantity = item.Quantity;
                    userItem.Price = item.Price;
                 
                }
            }

            _shopDBContext.Add(userItem);
            _shopDBContext.SaveChanges();

            bool enoughCash = false;

            foreach (var user in _shopDBContext.Users.ToList())
            {
                if (user.UserID == viewModel.CurrentUserID)
                {
                    if (viewModel.Funds > price)
                    {
                        enoughCash = true;
                        user.Funds = user.Funds - price;
                        _shopDBContext.SaveChanges();
                        viewModel.Funds = user.Funds;
                        _user.theUser.Funds = user.Funds;
                    }
                }
            }

            var errorModel = new ErrorPageViewModel();
            errorModel.UserFunds = viewModel.Funds;

            //var shopModel = new ShopViewModel();
            //shopModel.CurrentUserID = _user.theUser.UserID;
            //shopModel.Funds = _user.theUser.Funds;
            


            if (enoughCash)
            {
                return View(viewModel);
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


       




        //    //GetUserWhereIDIsFirst(viewModel.CurrentUserID);

        //    //_user.theUser.UserID = viewModel.CurrentUserID;
        //    //_user.theUser.Funds = viewModel.Funds;


       


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
