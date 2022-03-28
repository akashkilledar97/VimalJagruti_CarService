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
        IRepository<Domain.Entity.VehicleOwnerDetails> vehicleOwnerDetailsRepository { get; }
        IJobCardRepo jobCardRepo { get;  }
        IRepository<Domain.Entity.ProductCategory> productCategoryRepo { get; }
        IRepository<Domain.Entity.Product> productRepo { get; }
        IRepository<Domain.Entity.ProductQuantityManagement> productQtyRepo { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
