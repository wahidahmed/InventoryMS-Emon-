using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class Division : Base
    {
        public int? CountriesID { get; set; }
        public string Name { get; set; }
        public Country Countries { get; set; }
    }
}
