using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Areas.Master.Models
{
    public class SupplierViewModel
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string State { get; set; }

        public int? CountriesID { get; set; }
        public int? DivisionsID { get; set; }
        public int? DistrictsID { get; set; }
        public int? ThanasID { get; set; }
        public string Remarks { get; set; }


        public IEnumerable<Supplier> GetSuppliers { get; set; }
        public IEnumerable< Country> GetCountries { get; set; }
        public IEnumerable<Division> GetDivisions { get; set; }
        public IEnumerable<District> GetDistricts { get; set; }
        public IEnumerable<Thana> GetThanas { get; set; }
    }
}
