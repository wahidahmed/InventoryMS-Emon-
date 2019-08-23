using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Areas.Master.Models
{
    public class SupplierViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Street { get; set; }
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int? CountriesID { get; set; }

        [Required(ErrorMessage = "Division is required")]
        public int? DivisionsID { get; set; }

        [Required(ErrorMessage = "District is required")]
        public int? DistrictsID { get; set; }

        [Required(ErrorMessage = "Thana is required")]
        public int? ThanasID { get; set; }
        public string Remarks { get; set; }


        public IEnumerable<Supplier> GetSuppliers { get; set; }
        public IEnumerable< Country> GetCountries { get; set; }
        public IEnumerable<Division> GetDivisions { get; set; }
        public IEnumerable<District> GetDistricts { get; set; }
        public IEnumerable<Thana> GetThanas { get; set; }
    }
}
