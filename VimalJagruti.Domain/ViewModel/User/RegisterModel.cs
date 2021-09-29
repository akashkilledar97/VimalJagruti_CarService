using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Utils;

namespace VimalJagruti.Domain.ViewModel.User
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class RegisterModel : LoginModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class LoginResponse : BasicUserDetail
    {
        public int Id { get; set; }
    }
    public class BasicUserDetail : BaseUserDetails
    {
        public string AuthToken { get; set; }
        public int AuthTokenExpire { get; set; }
        public string RefreshToken { get; set; }
        public Roles Roles { get; set; }
    }

    public class BaseUserDetails 
    {
        public string Username { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Avatar { get; set; }
    }

    public class RefreshTokenAuthentication
    {
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
