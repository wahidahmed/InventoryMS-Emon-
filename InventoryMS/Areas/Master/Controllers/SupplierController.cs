using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMS.Areas.Master.Models;
using InventoryMS.DAL.Entity;
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
        private readonly IThanaService thanaService;
        public SupplierController(ISupplierService supplierService, ICountryService countryService, IDivisionService divisionService, IDistrictService districtService, IThanaService thanaService)
        {
            this.supplierService = supplierService;
            this.countryService = countryService;
            this.divisionService = divisionService;
            this.districtService = districtService;
            this.thanaService = thanaService;
        }

        public async Task<IActionResult> Index()
        {
            SupplierViewModel model = new SupplierViewModel
            {
                GetSuppliers = await supplierService.GetAll(),
                GetCountries=await countryService.GetAll()
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Index(SupplierViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.GetSuppliers = await supplierService.GetAll();
                model.GetCountries = await countryService.GetAll();
                return View(model);
            }
            Supplier entity = new Supplier
            {
                CountriesID=model.CountriesID,
                DivisionsID=model.DivisionsID,
                DistrictsID=model.DistrictsID,
                ThanasID=model.ThanasID,
                Name=model.Name,
                Remarks=model.Remarks,
                Street=model.Street,
                State=model.State
            };
            var id= await supplierService.Save(entity);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> GetDivision (int countriesId)
        {
            var divisionAll =await divisionService.GetAll();
            var result= divisionAll.Where(x => x.CountriesID == countriesId);
            return Json(result);
        }

        public async Task<IActionResult> GetDistrict(int divisionId)
        {
            var districtAll = await districtService.GetAll();
            var result = districtAll.Where(x => x.DivisionsID == divisionId);
            return Json(result);
        }

        public async Task<IActionResult> GetThana(int districtId)
        {
            var thanaAll = await thanaService.GetAll();
            var result = thanaAll.Where(x => x.DistrictsID == districtId);
            return Json(result);
        }
    }
}