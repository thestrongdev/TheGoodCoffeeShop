using GoodCoffeeShop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.DALModels
{
    public class UserItemsDAL
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserItemId { get; set; }

        public int UserId { get; set; }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }


        //couldn't get this to do what i needed in a timely manner. Will attemp again later

        //[ForeignKey("Id")]

        //public int UserId { get; set; }
        //public UsersDAL CurrentUser { get; set; }


        //[ForeignKey("Id")]

        //public int ItemId { get; set; }
        //public ItemsDAL PurchasedItem { get; set; }
    }
}
