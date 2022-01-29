using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.VehicleDetails;

namespace VimalJagruti.Repo.IRepository
{
    public interface IVehicleRepo : IRepository<VimalJagruti.Domain.Entity.VehicleDetails>
    {
        Task<Domain.ViewModel.VehicleDetails.VehicleDetails> GetVehicleDetails(string vehicleNumber);
        Task<ResponseViewModel<bool>> RegisterVehicle(NewVehicleDetails newVehicleDetails);
    }
}
