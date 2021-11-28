using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.User;
using VimalJagruti.Repo.IRepository;
using VimalJagruti.Services.IServices;
using VimalJagruti.Utils;
using VimalJagruti.Utils.ExtensionMethods;

namespace VimalJagruti.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoredProcedureRepo _spRepo;
        public UserServices(IUnitOfWork unitOfWork,IStoredProcedureRepo spRepo)
        {
            _unitOfWork = unitOfWork;
            _spRepo = spRepo;
        }
        public async Task<bool> AddUser(RegisterModel model)
        {
            ///Check if required string is empty
            if (string.IsNullOrEmpty(model.FirstName))
                return false;

            if (string.IsNullOrEmpty(model.LastName))
                return false;

            ///Generate username using custom method
            model.Username = Validations.GenerateUsername(model.FirstName, model.LastName);

            ///Generate password using custom method
            model.Password = Validations.GeneratePassword(model.PhoneNumber,model.FirstName);

            ///bind with user entity/table
            var user = new User
            {
                Username = model.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Roles = Utils.Roles.Staff,
                IsActive = true,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                RefreshToken = Guid.NewGuid().ToString()
            };

            //Add to database
            await _unitOfWork.userRepo.Add(user);

            return true;
        }

        public ServiceResponseModel<LoginResponse> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _unitOfWork.userRepo.Authenticate(username,password);

            //Return response in proper format
            LoginResponse response = new LoginResponse
            {
                Id = user.Id,
                FullName = string.IsNullOrEmpty(user.FullName) ? string.Empty : user.FullName,
                Username = user.Username,
                RefreshToken = user.RefreshToken,
                Roles = user.Roles
            };

            return new ServiceResponseModel<LoginResponse> 
            { 
                Data = response, 
                Message = Constants.LoginSuccess ,
                Status = true
            };
        }

        public async Task<ServiceResponseModel<LoginResponse>> AuthenticationToken(long userId, string token)
        {
            if (userId < 1)
                return null;

            var user = _unitOfWork.userRepo.AuthenticationToken(userId,token);

            if (user == null || user.RefreshToken != token || !user.IsActive || user.IsDeleted)
                Tuple.Create(false, Constants.LoginFailed, user);

            user.RefreshToken = Guid.NewGuid().ToString();
            await _unitOfWork.userRepo.Update(user);
            await _unitOfWork.SaveChangesAsync();

            LoginResponse response = new LoginResponse
            {
                Id = user.Id,
                Username = user.Username,
                FullName = string.IsNullOrEmpty(user.FullName) ? string.Empty : user.FullName,
                Roles = user.Roles,
                RefreshToken = user.RefreshToken
            };

            return new ServiceResponseModel<LoginResponse>
            {
                Data = response,
                Message = Constants.LoginSuccess,
                Status = true
            };

        }

        public Task<bool> ChangePassword(string oldPassword, string newPassword, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
