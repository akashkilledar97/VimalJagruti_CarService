using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.ViewModel.Inventory
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
    }
    public class ProductDetailsVM
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string CategoryName { get; set; }

    }
    public class ChangeProductCategory
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
