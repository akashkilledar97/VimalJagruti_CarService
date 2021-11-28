using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.VehicleDetails;
using VimalJagruti.Repo.IRepository;
using VimalJagruti.Services.IServices;

namespace VimalJagruti.Services.Services
{
    public class VehicleServices : IVehicleServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<VehicleDetails> GetVehicleDetails(string VehicleNumber)
        {
            if (string.IsNullOrEmpty(VehicleNumber))
                return new VehicleDetails();

            var details = await _unitOfWork.vehicleRepo.GetVehicleDetails(VehicleNumber);

            if (details == null)
                return null;

            return details;

        }
    }
}
