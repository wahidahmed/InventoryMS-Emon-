using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Areas.Master.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Product Name is required")]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        public string Brand { get; set; }
        public string Catagory { get; set; }
        public string Particurals { get; set; }

        [Required(ErrorMessage = "Unit is required")]
        [Display(Name = "Unit")]
        public string Unit { get; set; }
        

        public string Image { get; set; }

        [Required(ErrorMessage = "Supplier Name is required")]
        [Display(Name = "Supplier Name")]
        public int? SupplierID { get; set; }

        public IEnumerable<Product> GetProducts { get; set; }
        public IEnumerable<Supplier> GetSuppliers { get; set; }
    }
}
