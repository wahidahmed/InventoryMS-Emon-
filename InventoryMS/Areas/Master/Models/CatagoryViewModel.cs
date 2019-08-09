using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Areas.Master.Models
{
    public class CatagoryViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Catagory Name Is Required")]
        public string CatagoryName { get; set; }
        public string Remarks { get; set; }

        public IEnumerable<Catagory> GetCatagories { get; set; }
    }
}
