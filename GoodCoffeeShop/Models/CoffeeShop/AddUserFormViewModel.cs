using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.Models.CoffeeShop
{
    public class AddUserFormViewModel
    {

        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNum { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }
    }
}
