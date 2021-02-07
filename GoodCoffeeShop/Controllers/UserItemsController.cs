using GoodCoffeeShop.DALModels;
using GoodCoffeeShop.Services;
using GoodCoffeeShop.ViewModels.CoffeeShop;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Controllers
{
    public class UserItemsController : Controller
    {

        private readonly ICurrentUser _user;
        private readonly ShopDBContext _shopDBContext;
        private readonly IUserItems _userItem;

        public UserItemsController(ICurrentUser user, ShopDBContext shopDBContext, IUserItems useritem)
        {
            _user = user;
            _shopDBContext = shopDBContext;
            _userItem = useritem;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ItemDeleted()
        {
            return View();
        }

        public IActionResult AddItem() //LAB 24
        {

            return View("Shop");
        }

        public IActionResult ItemDetails(int id) //LAB 24
        {

            var viewModel = new ItemDetailsViewModel();

            viewModel.ItemToShow = GetItemWhereIDIsFirst(id);

            return View(viewModel);
        }

        public IActionResult DeleteConfirmation(int id, int userid) //LAB 24
        {
            var viewModel = new DeleteConfirmationViewModel();
            viewModel.ItemId = id;
            viewModel.UserId = userid;

            return View(viewModel);
        }

        public IActionResult DeleteItem(int id, int userid) //LAB 24
        {
 
            var usersItems = _shopDBContext.UserItems.Where(user => user.UserId == _user.theUser.UserID).ToList();

            foreach(var usersItem in usersItems)
            {
                if(usersItem.ItemId == id)
                {
                    _shopDBContext.UserItems.Remove(usersItem);
                    _shopDBContext.SaveChanges();
                    break;
                }
            }

            return View("ItemDeleted");
        }

        public IActionResult UserPurchases()
        {
            if (_user.loggedIn == false)
            {
              
                return View("MustBeLoggedIn");
            }

            var viewModel = new UserPurchasesViewModel();
            viewModel.CurrentUserID = _user.theUser.UserID;

            var itemIdsOfCurrentUser = _shopDBContext.UserItems.Where(user => user.UserId == viewModel.CurrentUserID).ToList();

       

            viewModel.userPurchases = itemIdsOfCurrentUser.Select(itemDAL => new Item
            {
                ItemID = itemDAL.ItemId,
                Description = itemDAL.Description,
                Name = itemDAL.Name,
                Price = itemDAL.Price,
                Quantity = itemDAL.Quantity

            }).ToList();

         
            return View(viewModel);  
        }

        private Item GetItemWhereIDIsFirst(int id)
        {
            ItemsDAL itemDAL = _shopDBContext.Items
                .Where(item => item.ItemID == id).FirstOrDefault();

            var item = new Item();
            item.ItemID = itemDAL.ItemID;
            item.Name = itemDAL.Name;
            item.Price = itemDAL.Price;
            item.Description = itemDAL.Description;
            item.Quantity = itemDAL.Quantity;

            return item;
        }


    }
}
