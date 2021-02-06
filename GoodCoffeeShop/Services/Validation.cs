using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GoodCoffeeShop.Services
{
    public class Validation
    {
        
               
        
        public static bool ValidatePW(OldUser oldUser)
        {
            if (oldUser.Password == null ||
              oldUser.PasswordConfirmation == null)
            {
                return false;
            }
            else if(oldUser.Password != oldUser.PasswordConfirmation)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateNames(OldUser oldUser)
        {
            Regex namePattern = new Regex(@"^[A-Z][[a-z]+$");

            if(oldUser.LastName == null || oldUser.FirstName == null)
            {
                return false;
            }
            else if(namePattern.IsMatch(oldUser.LastName) && namePattern.IsMatch(oldUser.FirstName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePhoneNumber(OldUser oldUser)
        {
            Regex phonePattern = new Regex(@"^\d{10}$");

            if (oldUser.PhoneNum==null) {

                return false;

            } else if (phonePattern.IsMatch(oldUser.PhoneNum) && oldUser.PhoneNum != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateEmail(OldUser oldUser)
        {
            Regex emailPattern = new Regex(@"^\w+@\w{5,10}.\w{2,3}$");

            if(oldUser.Email == null)
            {
                return false;
            }
            else if (emailPattern.IsMatch(oldUser.Email) && oldUser.Email!=null)
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
