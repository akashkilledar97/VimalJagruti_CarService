using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Repo.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepo userRepo { get; }
        IVehicleRepo vehicleRepo { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
