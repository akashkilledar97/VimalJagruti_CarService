using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.ViewModel.Common
{
    public class ResponseDataModel<T> where T : class
    {
        public T Data { get; set; }
        public int Count { get; set; }
    }
}
