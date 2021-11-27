using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.VehicleDetails;

namespace VimalJagruti.Services.IServices
{
    public interface IVehicleServices
    {
        /// <summary>
        /// This mathod is used to get vehicle details before job card
        /// </summary>
        /// <param name="VehicleNumber"></param>
        /// <returns></returns>
        Task<VehicleDetails> GetVehicleDetails(string VehicleNumber);
    }
}
