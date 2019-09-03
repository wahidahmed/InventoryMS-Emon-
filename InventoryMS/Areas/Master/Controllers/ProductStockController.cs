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
    public class ProductStockController : Controller
    {

        private readonly IProductStockService productStockService;
        public ProductStockController(IProductStockService productStockService)
        {
            this.productStockService = productStockService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductStockList()
        {
            ProductStockViewModel model = new ProductStockViewModel
            {
                GetProductStocks=await productStockService.GetAll()
            };
            return View(model);
        }
    }
}