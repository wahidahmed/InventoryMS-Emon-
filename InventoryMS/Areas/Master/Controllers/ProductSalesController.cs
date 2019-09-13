using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMS.Areas.Master.Models;
using InventoryMS.DAL.Entity;
using InventoryMS.Helper;
using InventoryMS.Services.Master.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMS.Areas.Master.Controllers
{
    [Area("Master")]
    public class ProductSalesController : Controller
    {
        private readonly ICountryService countryService;
        private readonly IDivisionService divisionService;
        private readonly IDistrictService districtService;
        private readonly IThanaService thanaService;

        private readonly IProductService productService;
        private readonly IProductStockDetailsService productStockDetailsService;
        private readonly IPersonnelInfoService personnelInfoService;
        private readonly IProductSalesDetailsService productSalesService;
        private readonly IProductSaleMasterService productSaleMasterService;
        private readonly IHelperService helperService;
        public ProductSalesController(ICountryService countryService, IDivisionService divisionService, IDistrictService districtService, IThanaService thanaService, IProductService productService, IProductStockDetailsService productStockDetailsService, IPersonnelInfoService personnelInfoService, IProductSalesDetailsService productSalesService, IProductSaleMasterService productSaleMasterService, IHelperService helperService)
        {
            this.countryService = countryService;
            this.divisionService = divisionService;
            this.districtService = districtService;
            this.thanaService = thanaService;
            this.productService = productService;
            this.productStockDetailsService = productStockDetailsService;
            this.personnelInfoService = personnelInfoService;
            this.productSalesService = productSalesService;
            this.helperService = helperService;
        }
        public async Task<IActionResult> Index()
        {
            ProductSalesViewModel model = new ProductSalesViewModel
            {
                GetCountries = await countryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductSalesViewModel model)
        {
            PersonnelInfo personnelInfo = new PersonnelInfo
            {
                ID=model.ID,
                Name=model.Name,
                PersonnelCode=model.PersonnelCode,
                Street=model.Street,
                State=model.State,
                CountriesID=model.CountriesID,
                DivisionsID=model.DivisionsID,
                DistrictsID=model.DistrictsID,
                ThanasID=model.ThanasID
            };
          var cusId=  await personnelInfoService.Save(personnelInfo);

            ProductSaleMaster productSaleMaster = new ProductSaleMaster
            {
                ID=model.ID
            };
            return Json(true);
        }

        public async Task<IActionResult> GetDivision(int countriesId)
        {
            var divisionAll = await divisionService.GetAll();
            var result = divisionAll.Where(x => x.CountriesID == countriesId);
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

        public async Task<IActionResult> GetProducts()
        {
            var result = await productService.GetAll();

            return Json(result);
        }

        public async Task<IActionResult> GetProductDetailsForStock(int? id)
        {
            var result = await productStockDetailsService.GetProductDetailsForStock(id);

            return Json(result);
        }


        public async Task<IActionResult> GetPersonalsCode()
        {
            int? maxId = await personnelInfoService.MaxId();
            var result= helperService.key(maxId);
            return Json(result);
        }
    }
}