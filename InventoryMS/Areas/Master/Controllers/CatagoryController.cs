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
    public class CatagoryController : Controller
    {
        private readonly ICatagoryService catagoryService;
        public CatagoryController(ICatagoryService catagoryService)
        {
            this.catagoryService = catagoryService;
        }
        public async Task<IActionResult> Index()
        {
            CatagoryViewModel model = new CatagoryViewModel
            {
                GetCatagories = await catagoryService.GetAll()
            };
            return View(model);
        }

        public async Task<IActionResult> Index(CatagoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.GetCatagories = await catagoryService.GetAll();
                return View(model);
            }
            Catagory entity = new Catagory
            {
                ID=model.ID,
                CatagoryName=model.CatagoryName,
                Remarks=model.Remarks
            };
            await catagoryService.Save(entity);
            return View();
        }
    }
}