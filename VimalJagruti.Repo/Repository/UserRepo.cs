using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Repo.IRepository;

namespace VimalJagruti.Repo.Repository
{
    public class UserRepo : GenericRepository<User>, IUserRepo
    {
        private readonly Context _context;
        private readonly IStoredProcedureRepo _spRepo;

        public UserRepo(Context context, IStoredProcedureRepo spRepo) : base(context)
        {
            _context = context;
            _spRepo = spRepo;

        }

        public User Authenticate(string username, string password)
        {
            //Attach parameters
            DynamicParameters param = new DynamicParameters();
            param.Add("@username", username);

            var sp = "LoginAndGetDetails";

            //Execute stored procedure
            User user = _spRepo.Get<User>(sp, param);

            if (user == null)
                return null;

            //Verify password
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;

            return user;
        }

        public async Task<bool> UpdateStatus(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user.IsDeleted)
                return false;

            user.IsActive = !user.IsActive;
            user.UpdatedOn = DateTime.UtcNow;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;

        }

        public Task<ResponseDataModel<User>> UserList()
        {
            throw new NotImplementedException();
        }

        public User AuthenticationToken(long userId, string token)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@userId", userId);

            var sp = "spRefreshToken";

            //Execute stored procedure
            User user = _spRepo.Get<User>(sp, param);

            if (user == null)
                return null;


            return user;
        }
    }
}
