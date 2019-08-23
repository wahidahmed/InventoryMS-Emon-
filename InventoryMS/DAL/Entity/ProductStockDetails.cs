using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class ProductStockDetails:Base
    {
        public int? ProductsID { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Total { get; set; }
        public string EntryDate { get; set; }

        public Product Products { get; set; }
    }
}
