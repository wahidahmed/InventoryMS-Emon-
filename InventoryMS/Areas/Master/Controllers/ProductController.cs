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
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ISupplierService supplierService;

        public ProductController(IProductService productService, ISupplierService supplierService)
        {
            this.productService = productService;
            this.supplierService = supplierService;
        }
        public async Task<IActionResult> Index()
        {
            ProductViewModel model = new ProductViewModel
            {
                GetProducts=await productService.GetAll(),
                GetSuppliers=await supplierService.GetAll()
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Index(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.GetProducts = await productService.GetAll();
                model.GetSuppliers = await supplierService.GetAll();

                return View(model);
            }
            var productList = await productService.GetAll();
            string code = "";
            if (productList.Count() > 0)
            {
               string prodId = productList.Max(x => x.ID).ToString();
                code= "000" + prodId;
            }
            else
            {
                code = "0001";
            }
            Product entity = new Product
            {
                ID = model.ID,
                ProductName = model.ProductName,
                Brand = model.Brand,
                Catagory = model.Catagory,
                Particurals = model.Particurals,
                SupplierID = model.SupplierID,
                ProductCode = code,
                Unit=model.Unit
            };
           await productService.Save(entity);
            return RedirectToAction(nameof(Index));
        }
    }
}