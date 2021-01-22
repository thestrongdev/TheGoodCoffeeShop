using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GoodCoffeeShop.Services
{
    public class Validation
    {
        public static bool ValidatePW(User user)
        {
            if (user.Password == null ||
              user.PasswordConfirmation == null)
            {
                return false;
            }
            else if(user.Password != user.PasswordConfirmation)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateNames(User user)
        {
            Regex namePattern = new Regex(@"^[A-Z][[a-z]+$");

            if(user.LastName == null || user.FirstName == null)
            {
                return false;
            }
            else if(namePattern.IsMatch(user.LastName) && namePattern.IsMatch(user.FirstName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePhoneNumber(User user)
        {
            Regex phonePattern = new Regex(@"^\d{10}$");

            if (user.PhoneNum==null) {

                return false;

            } else if (phonePattern.IsMatch(user.PhoneNum) && user.PhoneNum != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateEmail(User user)
        {
            Regex emailPattern = new Regex(@"^\w+@\w{5,10}.\w{2,3}$");

            if(user.Email == null)
            {
                return false;
            }
            else if (emailPattern.IsMatch(user.Email) && user.Email!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
