using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.SqlModel
{
    public class ProductDetailsForStock
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Catagory { get; set; }
        public string Particurals { get; set; }
        public decimal? TotalQty { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? PerCost { get; set; }
    }
}
