using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Utils;

namespace VimalJagruti.Domain.ViewModel.Common
{
    public class CurrentUser
    {
        public int Id { get; set; }
        public Roles Roles { get; set; }
        public string Name { get; set; }
    }
}
