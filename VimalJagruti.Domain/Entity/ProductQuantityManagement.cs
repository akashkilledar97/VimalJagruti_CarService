using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.Entity
{
    public class ProductQuantityManagement : CommonEntity
    {
        [ForeignKey("Product")]
        public int ProductId_FK { get; set; }
        public string BatchNumber { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        //Distributor information
        //public int DistributorId {get;set;}

        [JsonIgnore]
        public Product Product { get; set; }

    }
}
