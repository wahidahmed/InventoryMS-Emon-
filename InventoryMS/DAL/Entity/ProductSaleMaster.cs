using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class ProductSaleMaster:Base
    {
        public int? PersonnelInfoID { get; set; }
        public string SalesDate { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? Total { get; set; }
        public PersonnelInfo PersonnelInfo { get; set; }
    }
}
