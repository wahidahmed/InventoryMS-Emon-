using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class Country : Base
    {
        public string Name { get; set; }
        public string Remarks { get; set; }
    }
}
