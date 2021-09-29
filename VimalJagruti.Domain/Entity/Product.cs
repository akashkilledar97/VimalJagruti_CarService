using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.Entity
{
    public class Product : CommonEntity
    {
        public string ProductName { get; set; }

        [ForeignKey("ProductCategory")]
        public int CategoryId_FK { get; set; }

        [JsonIgnore]
        public ProductCategory ProductCategory { get; set; }

    }
}
