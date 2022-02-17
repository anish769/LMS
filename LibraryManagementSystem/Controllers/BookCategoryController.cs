using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookCategoryController : Controller
    {
        BookCategoryService bookCategoryService;
        public BookCategoryController()
        {
            bookCategoryService = new BookCategoryService();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookCategoryModel model)
        {
            bookCategoryService.SaveData(model);
            return RedirectToAction("Index");
        }
        // GET: BookCategory
        public ActionResult Index()
        {
            var data = bookCategoryService.DisplayData();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Models.BookCategoryModel bookCategoryModel)
        {
            bookCategoryService.SaveData(bookCategoryModel);
            var data = bookCategoryService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = bookCategoryService.GetData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(BookCategoryModel model)
        {
            bookCategoryService.UpdateData(model);
            var dataList = bookCategoryService.DisplayData();
            return View("DisplayList", dataList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookCategoryService.DeleteData(id);
            var dataList = bookCategoryService.DisplayData();
            return View("DisplayList", dataList);
        }
        public ActionResult _DisplayPartialData()
        {
            var dataList = bookCategoryService.DisplayData();
            return View(dataList);
        }
    }
}