using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.Entity
{
    public class Feedback : CommonEntity
    {
        [ForeignKey("VehicleOwner")]
        public int VehicleOwnerId_FK { get; set; }
        public string FeedbackMessage { get; set; }

        [JsonIgnore]
        public VehicleOwnerDetails VehicleOwner { get; set; }

    }
}
