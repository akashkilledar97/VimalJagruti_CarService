using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VimalJagruti.Utils;

namespace VimalJagruti.Domain.Entity
{
    public class VehicleDetails : CommonEntity
    {
        [ForeignKey("VehicleOwner")]
        public int VehicleOwnerId_FK { get; set; }

        public string VehicleNumber { get; set; }
        
        public string VehicleBrand { get; set; }
        
        public string VehicleName { get; set; }
        
        [MaxLength(50)]
        public string ChassisNumber { get; set; }
        
        [MaxLength(50)]
        public string EngineNumber { get; set; }
        
        public FuelType FuelType { get; set; }
        
        
        public string VehicleQR { get; set; }

        [JsonIgnore]
        public VehicleOwnerDetails VehicleOwner { get; set; }

    }
}
