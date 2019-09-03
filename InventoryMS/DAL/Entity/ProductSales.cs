using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class ProductSales:Base
    {
        public int? PersonnelInfoID { get; set; }

        public string SalesDate { get; set; }

        public int? ProductsID { get; set; }

        public decimal? Qty { get; set; }

        public decimal? UnitSalesPrice { get; set; }

        public string Remarks { get; set; }

        public Product Products { get; set; }
       
        public PersonnelInfo PersonnelInfo { get; set; }
    }
}
