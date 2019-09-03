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
    public class ProductSalesController : Controller
    {
        private readonly ICountryService countryService;
        private readonly IDivisionService divisionService;
        private readonly IDistrictService districtService;
        private readonly IThanaService thanaService;

        private readonly IProductService productService;
        private readonly IProductStockDetailsService productStockDetailsService;
        public ProductSalesController(ICountryService countryService, IDivisionService divisionService, IDistrictService districtService, IThanaService thanaService, IProductService productService, IProductStockDetailsService productStockDetailsService)
        {
            this.countryService = countryService;
            this.divisionService = divisionService;
            this.districtService = districtService;
            this.thanaService = thanaService;
            this.productService = productService;
            this.productStockDetailsService = productStockDetailsService;
        }
        public async Task<IActionResult> Index()
        {
            ProductSalesViewModel model = new ProductSalesViewModel
            {
                GetCountries = await countryService.GetAll()
            };
            return View(model);
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
    }
}