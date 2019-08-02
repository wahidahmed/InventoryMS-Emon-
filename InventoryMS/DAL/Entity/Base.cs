using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class Base
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
