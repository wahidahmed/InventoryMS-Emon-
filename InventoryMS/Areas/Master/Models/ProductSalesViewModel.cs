using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Areas.Master.Models
{
    public class ProductSalesViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }

    
        public string PersonnelCode { get; set; }
        public string Street { get; set; }
        public string State { get; set; }

   
        public int? CountriesID { get; set; }

        public int? DivisionsID { get; set; }

    
        public int? DistrictsID { get; set; }

        public int? ThanasID { get; set; }

        public string SalesDate { get; set; }

        public IEnumerable<Country> GetCountries { get; set; }

        public List<ProductDetails> ProductDetails { get; set; }
    }

    public class ProductDetails
    {

        public int? ProductsID { get; set; }


        public decimal? Qty { get; set; }

        public decimal? UnitSalesPrice { get; set; }


        public decimal? Discount { get; set; }

        public string Remarks { get; set; }

    }
}
