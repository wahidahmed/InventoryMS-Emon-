using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMS.Areas.Master.Models;
using InventoryMS.Services.Master.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMS.Areas.Master.Controllers
{
    [Area("Master")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService supplierService;
        private readonly ICountryService countryService;
        private readonly IDivisionService divisionService;
        private readonly IDistrictService districtService;
        public SupplierController(ISupplierService supplierService, ICountryService countryService, IDivisionService divisionService, IDistrictService districtService)
        {
            this.supplierService = supplierService;
            this.countryService = countryService;
            this.divisionService = divisionService;
            this.districtService = districtService;
        }

        public async Task<IActionResult> Index()
        {
            SupplierViewModel model = new SupplierViewModel
            {
                GetSuppliers = await supplierService.GetAll()
            };
            return View(model);
        }
    }
}