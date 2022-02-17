using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        BookService bookService;
        public BookController()
        {
            bookService = new BookService();
        }
        // GET: Book
        public ActionResult Index()
        {
            var data = bookService.DisplayData();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Models.BookModel bookModel)
        {
            bookService.SaveData(bookModel);
            var data =bookService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = bookService.GetData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(BookModel model)
        {
            bookService.UpdateData(model);
            var dataList = bookService.DisplayData();
            return View("DisplayList", dataList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookService.DeleteData(id);
            var dataList = bookService.DisplayData();
            return View("DisplayList", dataList);
        }
        public ActionResult _DisplayPartialData()
        {
            var dataList = bookService.DisplayData();
            return View(dataList);
        }
    }
}