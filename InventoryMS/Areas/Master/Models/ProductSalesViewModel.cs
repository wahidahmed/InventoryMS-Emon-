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

        public int? PersonnelInfoID { get; set; }

        public string SalesDate { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [Display(Name = "Product Name")]
        public int? ProductsID { get; set; }


        [Required(ErrorMessage ="Quantity is required")]
        [Display(Name = "Quantity")]
        public decimal? Qty { get; set; }

        [Required(ErrorMessage = "Unit SalesPrice is required")]
        [Display(Name = "Unit SalesPrice")]
        public decimal? UnitSalesPrice { get; set; }

      
        public decimal? Discount { get; set; }

        public string Remarks { get; set; }

        public PersonnelInfoViewModel PersonnelInfoVM { get; set; }
        
        public IEnumerable<Country> GetCountries { get; set; }


    }
}
