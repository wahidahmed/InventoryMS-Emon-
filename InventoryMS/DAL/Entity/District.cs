using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class District : Base
    {
        public int? DivisionsID { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }

        public Division Divisions { get; set; }
    }
}
