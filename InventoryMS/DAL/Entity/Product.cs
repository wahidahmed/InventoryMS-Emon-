using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class Product : Base
    {
        public int? BrandsID { get; set; }
        public string ProductName { get; set; }
        public string ShortName { get; set; }
        public string Remarks { get; set; }
        public Brand Brands { get; set; }
    }
}
