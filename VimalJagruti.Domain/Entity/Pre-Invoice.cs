using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.Entity
{
    public class Pre_Invoice : CommonEntity
    {
        [ForeignKey("JobCard")]
        public int JobCardIdFK_FK { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceId_FK { get; set; }
        public List<Particuler> Particulers { get; set; }
        public List<Labour> Labours { get; set; }

        [JsonIgnore]
        public JobCard JobCard { get; set; }
        [JsonIgnore]
        public Invoice Invoice { get; set; }

    }
    public class Particuler
    {
        public int ItemId { get; set; }
        public string BatchNumber { get; set; }
        public double Price { get; set; }
    }
    public class Labour
    {
        public string Work { get; set; }
        public double Price { get; set; }
    }
}
