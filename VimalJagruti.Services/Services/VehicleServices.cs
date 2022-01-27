using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
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

        public async Task<ResponseViewModel<bool>> NewVehicleRegister(NewVehicleDetails newVehicleDetails)
        {
            if (string.IsNullOrEmpty(newVehicleDetails.VehicleDetails.VehicleNumber) || string.IsNullOrEmpty(newVehicleDetails.OwnerNumber))
                return new ResponseViewModel<bool>
                {
                    Data = false,
                    Message = VimalJagruti.Utils.Constants.NoRegistrationNumber,
                    StatusCode = System.Net.HttpStatusCode.NotAcceptable
                };

            Domain.Entity.VehicleOwnerDetails ownerDetails = new Domain.Entity.VehicleOwnerDetails
            {
                FirstName = newVehicleDetails.OwnerFirstName,
                LastName = newVehicleDetails.OwnerLastName,
                PhoneNumber = newVehicleDetails.OwnerNumber,
                Email = string.Empty
            };

            var newOwner = await _unitOfWork.vehicleOwnerDetailsRepository.Add(ownerDetails);

            if (!newOwner)
                return new ResponseViewModel<bool>
                {
                    Data = false,
                    Message = Utils.Constants.GeneralError,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };

            Domain.Entity.VehicleDetails vehicleDetails = new Domain.Entity.VehicleDetails
            {
                ChassisNumber = newVehicleDetails.VehicleDetails.ChassisNumber,
                FuelType = newVehicleDetails.VehicleDetails.FuelType,
                VehicleName = newVehicleDetails.VehicleDetails.VehicleName,
                VehicleBrand = newVehicleDetails.VehicleDetails.VehicleBrand,
                EngineNumber = string.IsNullOrEmpty(newVehicleDetails.VehicleDetails.EngineNumber) || newVehicleDetails.VehicleDetails.EngineNumber == "0" ? null : newVehicleDetails.VehicleDetails.EngineNumber,
                VehicleNumber = newVehicleDetails.VehicleDetails.VehicleNumber,
                VehicleOwnerId_FK = ownerDetails.Id,
            };

            var vehicle = await _unitOfWork.vehicleRepo.Add(vehicleDetails);

            if (!vehicle)
                return new ResponseViewModel<bool>
                {
                    Data = false,
                    Message = Utils.Constants.GeneralError,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };

            return new ResponseViewModel<bool>
            {
                Data = true,
                Message = Utils.Constants.VehicleRegistered,
                StatusCode = System.Net.HttpStatusCode.OK
            };


        }
    }
}
