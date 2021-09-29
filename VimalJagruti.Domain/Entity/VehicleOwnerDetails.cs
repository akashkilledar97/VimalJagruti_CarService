using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.Entity
{
    public class VehicleOwnerDetails : CommonEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
