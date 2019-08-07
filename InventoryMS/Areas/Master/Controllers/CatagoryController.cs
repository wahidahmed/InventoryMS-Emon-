using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMS.Areas.Master.Controllers
{
    public class CatagoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}