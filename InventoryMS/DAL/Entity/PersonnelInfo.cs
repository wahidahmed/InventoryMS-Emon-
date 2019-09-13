using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{

    public class PersonnelInfo:Base
    {
        public string Name { get; set; }
        public string PersonnelCode { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public int? CountriesID { get; set; }
        public int? DivisionsID { get; set; }
        public int? DistrictsID { get; set; }
        public int? ThanasID { get; set; }
    }
}
