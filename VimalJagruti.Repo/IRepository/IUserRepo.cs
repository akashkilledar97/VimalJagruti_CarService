using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;
using VimalJagruti.Domain.ViewModel.Common;

namespace VimalJagruti.Repo.IRepository
{
    public interface IUserRepo : IRepository<User>
    {
        Task<ResponseDataModel<User>> UserList();
        Task<bool> UpdateStatus(int id);

        User Authenticate(string username, string password);
        User AuthenticationToken(long userId, string token);
    }
}
