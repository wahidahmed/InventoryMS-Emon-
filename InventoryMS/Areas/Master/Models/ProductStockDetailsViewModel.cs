using InventoryMS.DAL.Entity;
using InventoryMS.Services.Master.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Areas.Master.Models
{
    public class ProductStockDetailsViewModel
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [Display(Name = "Product Name")]
       
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        public decimal? Qty { get; set; }

        [Required(ErrorMessage = "UnitPrice is required")]
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [Display(Name = "Cost")]
        public decimal? Cost { get; set; }

        public string EntryDate { get; set; }

        public IEnumerable<ProductStockDetails> productStockDetails { get; set; }

        public IEnumerable<Product> GetProducts { get; set; }
    }
}
