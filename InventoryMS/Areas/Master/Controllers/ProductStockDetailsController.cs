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
    public class ProductStockDetailsController : Controller
    {

        private readonly IProductStockDetailsService productStockDetailsService;
        private readonly IProductService productService;

        public ProductStockDetailsController(IProductStockDetailsService productStockDetailsService, IProductService productService)
        {
            this.productStockDetailsService = productStockDetailsService;
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            ProductStockDetailsViewModel model = new ProductStockDetailsViewModel
            {
                GetProducts=await productService.GetAll(),
                productStockDetails=await productStockDetailsService.GetAll()
            };
            return View(model);
        }

        public async Task<IActionResult> GetProducts()
        {
            var result = await productService.GetAll();
            
            return Json(result);
        }
    }
}