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
    public class ProductStockDetailsController : Controller
    {

        private readonly IProductStockDetailsService productStockDetailsService;
        private readonly IProductService productService;

        private readonly IProductStockService productStockService;

        public ProductStockDetailsController(IProductStockDetailsService productStockDetailsService, IProductService productService, IProductStockService productStockService)
        {
            this.productStockDetailsService = productStockDetailsService;
            this.productService = productService;
            this.productStockService = productStockService;
        }
        public async Task<IActionResult> Index()
        {
            ProductStockDetailsViewModel model = new ProductStockDetailsViewModel
            {
                GetProducts = await productService.GetAll(),
                productStockDetails = await productStockDetailsService.GetAll()
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ProductStockDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.GetProducts = await productService.GetAll();
                model.productStockDetails = await productStockDetailsService.GetAll();

                return View(model);
            }
            ProductStockDetails entity = new ProductStockDetails
            {
                ID = model.ID,
                ProductsID = model.ProductID,
                Qty = model.Qty,
                UnitPrice = model.UnitPrice,
                Cost = model.Cost,
                EntryDate = model.EntryDate,
                Total = (model.Qty * model.UnitPrice) + model.Cost
            };
            await productStockDetailsService.Save(entity);
            
             await StockSetUp(model.ProductID);
            
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> StockSetUp(int? ProductID)
        {
            var prodDetail = await productStockDetailsService.GetByProduct(ProductID);
            var totalQty = prodDetail.Sum(x => x.Qty);
            var totalCost = prodDetail.Sum(x => x.Total);
            var perCost = totalCost / totalQty;
            int prodStockId = 0;

            var ProductStock = await productStockService.GetByProductId(ProductID);
            if (ProductStock.Count() > 0)
            {
                prodStockId = ProductStock.FirstOrDefault().ID;
            }
            ProductStock productStocks = new ProductStock
            {
                ProductsID = ProductID,
                ID = prodStockId,
                TotalQty = totalQty,
                TotalCost = totalCost,
                PerCost = perCost
            };

            await productStockService.Save(productStocks);


            return Json(true);
        }

        public async Task<IActionResult> GetProducts()
        {
            var result = await productService.GetAll();

            return Json(result);
        }

    }
}