using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Utils;

namespace VimalJagruti.Domain.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string RefreshToken { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        public Roles Roles { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
        public DateTime LastLoginDate { get; set; }
    }
}
