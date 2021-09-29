using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Utils.ExtensionMethods
{
    public static class Validations
    {
        public static bool EmailValid(this string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string GenerateUsername(string firstName,string Lastname)
        {
            string username = firstName;

            username = username + DateTime.UtcNow.Day.ToString() + DateTime.UtcNow.Month.ToString();

            return username.ToLower() ;
        }

        public static string GeneratePassword(string phoneNumber, string firstName)
        {
            string password = phoneNumber + firstName.Substring(0,3).ToLower();

            return password;
        }
    }
}
