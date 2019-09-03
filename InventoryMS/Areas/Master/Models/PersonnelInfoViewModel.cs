using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Areas.Master.Models
{
    public class PersonnelInfoViewModel
    {
        [Required(ErrorMessage ="Customer Name is required")]
        [Display(Name ="Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customer Code is required")]
        [Display(Name = "Customer Code")]
        public string PersonnelCode { get; set; }
        public string Street { get; set; }
        public string State { get; set; }

        [Display(Name = "Country Name")]
        public int? CountriesID { get; set; }

        [Display(Name = "Division Name")]
        public int? DivisionsID { get; set; }

        [Display(Name = "District Name")]
        public int? DistrictsID { get; set; }

        [Display(Name = "Thana Name")]
        public int? ThanasID { get; set; }


        
    }
}
