using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class ProductSalesDetails:Base
    {
        public int? ProductSaleMasterID { get; set; }

        public int? ProductsID { get; set; }

        public decimal? Qty { get; set; }

        public decimal? UnitSalesPrice { get; set; }

        public string Remarks { get; set; }

        public decimal? Discount { get; set; }

        public Product Products { get; set; }
       
        public ProductSaleMaster ProductSaleMaster { get; set; }
    }
}
