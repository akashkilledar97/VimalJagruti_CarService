using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.Entity
{
    public class Invoice : CommonEntity
    {
        public double NetAmount { get; set; } 
        public double GSTAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double TotalAmount { get; set; }

    }
}
