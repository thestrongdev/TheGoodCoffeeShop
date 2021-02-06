using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.DALModels
{
    public class ItemsDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("Id")]
        public string Id { get; set; }

        public IdentityUser User { get; set; }
    }
}
