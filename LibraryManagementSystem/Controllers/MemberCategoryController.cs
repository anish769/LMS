using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class MemberCategoryController : Controller
    {
        MemberCategoryService memberCategoryService;
        public MemberCategoryController()
        {
            memberCategoryService = new MemberCategoryService();
        }

        // GET: MemberCategory
        public ActionResult Index()
        {
            var data = memberCategoryService.DisplayData();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Models.MemberCategoryModel memberCategoryModel)
        {
            memberCategoryService.SaveData(memberCategoryModel);
            var data = memberCategoryService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = memberCategoryService.GetData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(MemberCategoryModel model)
        {
            memberCategoryService.UpdateData(model);
            var dataList = memberCategoryService.DisplayData();
            return View("DisplayList", dataList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            memberCategoryService.DeleteData(id);
            var dataList = memberCategoryService.DisplayData();
            return View("DisplayList", dataList);
        }
        public ActionResult _DisplayPartialData()
        {
            var dataList = memberCategoryService.DisplayData();
            return View(dataList);
        }
    }
}