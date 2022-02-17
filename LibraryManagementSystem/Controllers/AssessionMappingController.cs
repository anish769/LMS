using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AssessionMappingController : Controller
    {
        AssessionMappingService assessionMappingService;
        public AssessionMappingController()
        {
            assessionMappingService = new AssessionMappingService();

        }
        // GET: AssessionMapping
        public ActionResult Index()
        {
            var data = assessionMappingService.DisplayData();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Models.AssessionMappingModel assessionMappingModel)
        {
            assessionMappingService.SaveData(assessionMappingModel);
            var data = assessionMappingService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = assessionMappingService.GetData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(AssessionMappingModel model)
        {
            assessionMappingService.UpdateData(model);
            var dataList = assessionMappingService.DisplayData();
            return View("DisplayList", dataList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            assessionMappingService.DeleteData(id);
            var dataList = assessionMappingService.DisplayData();
            return View("DisplayList", dataList);
        }
        public ActionResult _DisplayPartialData()
        {
            var dataList = assessionMappingService.DisplayData();
            return View(dataList);
        }
    }
}