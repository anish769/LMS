using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class FineController : Controller
    {
        FineService fineService;
        public FineController()
        {
            fineService = new FineService();
        }
        // GET: Fine
        public ActionResult Index()
        {
            var data = fineService.DisplayData();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Models.FineModel fineModel)
        {
            fineService.SaveData(fineModel);
            var data = fineService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = fineService.GetData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(FineModel model)
        {
            fineService.UpdateData(model);
            var dataList = fineService.DisplayData();
            return View("DisplayList", dataList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            fineService.DeleteData(id);
            var dataList = fineService.DisplayData();
            return View("DisplayList", dataList);
        }
        public ActionResult _DisplayPartialData()
        {
            var dataList = fineService.DisplayData();
            return View(dataList);
        }
    }
}