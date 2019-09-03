using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Areas.Master.Models
{
    public class ProductStockViewModel
    {
        public int? ID { get; set; }
        public int? ProductsID { get; set; }
        public decimal? TotalQty { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? PerCost { get; set; }

        public IEnumerable<ProductStock> GetProductStocks { get; set; }
    }
}
