using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        AuthorService authorService;
        public AuthorController()
        {
            authorService = new AuthorService();
        }
        // GET: Author
        public ActionResult Index()
        {
            var data = authorService.DisplayData();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Models.AuthorModel authorModel)
        {
            authorService.SaveData(authorModel);
            var data = authorService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = authorService.GetData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(AuthorModel model)
        {
            authorService.UpdateData(model);
            var dataList = authorService.DisplayData();
            return View("DisplayList", dataList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            authorService.DeleteData(id);
            var dataList = authorService.DisplayData();
            return View("DisplayList", dataList);
        }
        public ActionResult _DisplayPartialData()
        {
            var dataList = authorService.DisplayData();
            return View(dataList);
        }
    }
}