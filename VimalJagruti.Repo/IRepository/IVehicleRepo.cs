using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;

namespace VimalJagruti.Repo.IRepository
{
    public interface IVehicleRepo : IRepository<VehicleDetails>
    {
        Task<Domain.ViewModel.VehicleDetails.VehicleDetails> GetVehicleDetails(string vehicleNumber);
    }
}
