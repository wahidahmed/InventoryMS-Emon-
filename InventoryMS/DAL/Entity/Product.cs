using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL.Entity
{
    public class Product:Base
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Catagory { get; set; }
        public string Particurals { get; set; }
        
        public string Unit { get; set; }
        public string Image { get; set; }
       
        public int? SupplierID { get; set; }

        
    }
}
