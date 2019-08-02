using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class Thana : Base
    {
        public int? DistrictsID { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public District Districts { get; set; }
    }
}
