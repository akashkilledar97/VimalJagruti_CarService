using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.User;

namespace VimalJagruti.Services.IServices
{
    public interface IUserServices
    {
        /// <summary>
        /// function to Register .. # not applicable now
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Register(RegisterModel model);

        /// <summary>
        /// function to Login of staff member
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ServiceResponseModel<LoginResponse> Authenticate(string username,string password);

        /// <summary>
        /// Function to authenticate token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<ServiceResponseModel<LoginResponse>> AuthenticationToken(long userId, string token);

        /// <summary>
        /// Function to add staff by owner
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> AddUser(RegisterModel model);

        /// <summary>
        /// Function to change password of staff members
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> ChangePassword(string oldPassword,string newPassword,int userId);
    }
}
