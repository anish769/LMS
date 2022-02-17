using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class SubjectController : Controller
    {
        SubjectService subjectService;
        public SubjectController()
        {
            subjectService = new SubjectService(); //initialization
        }

        // GET: Subject
        public ActionResult Index()
        {
            var data = subjectService.DisplayData();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Models.SubjectModel subjectModel)
        {
            subjectService.SaveData(subjectModel);
            var data = subjectService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = subjectService.GetData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(SubjectModel model)
        {
            subjectService.UpdateData(model);
            var dataList = subjectService.DisplayData();
            return View("DisplayList", dataList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            subjectService.DeleteData(id);
            var dataList = subjectService.DisplayData();
            return View("DisplayList", dataList);
        }
        public ActionResult _DisplayPartialData()
        {
            var dataList = subjectService.DisplayData();
            return View(dataList);
        }
    }
}