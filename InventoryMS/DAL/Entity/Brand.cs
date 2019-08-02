using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class Brand : Base
    {
        public int? CatagoriesID { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }

        public Catagory Catagories { get; set; }
    }
}
