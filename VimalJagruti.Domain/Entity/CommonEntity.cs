using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.Entity
{
    public class CommonEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn => DateTime.Now;
        public DateTime UpdatedOn => DateTime.Now;

    }
}
