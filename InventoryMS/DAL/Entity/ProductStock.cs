using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class ProductStock:Base
    {
        public int? ProductsID { get; set; }
        public decimal? TotalQty { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? PerCost { get; set; }

        public Product Products { get; set; }
    }
}
