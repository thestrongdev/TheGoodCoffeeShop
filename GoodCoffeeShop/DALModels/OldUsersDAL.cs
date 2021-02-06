using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCoffeeShop.DALModels
{
    public class OldUsersDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OldUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNum { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public double Funds { get; set; }

        public string UserName { get; set; }

    }
}
