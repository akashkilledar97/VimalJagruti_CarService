using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Utils;

namespace VimalJagruti.Domain.ViewModel.VehicleDetails
{
    public class VehicleDetails
    {
        public int Id { get; set; }
        public string VehicleNumber { get; set; }

        public string VehicleBrand { get; set; }

        public string VehicleName { get; set; }

        [MaxLength(50)]
        public string ChassisNumber { get; set; }

        [MaxLength(50)]
        public string EngineNumber { get; set; }

        public FuelType FuelType { get; set; }

        public string VehicleQR { get; set; }
    }
    public class NewVehicleDetails
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerNumber { get; set; }

        public VehicleDetails VehicleDetails { get; set; }
    }
}
