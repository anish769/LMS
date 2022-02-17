using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookIssueReturnController : Controller
    {
        BookIssueReturnService bookIssueReturnService;
        BookService bookService;
        MemberService memberService;
        AssessionMappingService assessionMappingService;
        public BookIssueReturnController()
        {
            bookIssueReturnService = new BookIssueReturnService();
            bookService = new BookService();
            memberService = new MemberService();
            assessionMappingService = new AssessionMappingService();
        }
        // GET: BookIssueReturn
        public ActionResult Index()
        {
            var data = new MemberModel();
            data.ToIssueBookModel = new BookModel();
            data.ToIssueBookModel.BookIssueList = bookService.DisplayDataComboList();
            data.IssuedBookList = new System.Collections.Generic.List<BookIssueReturnModel>();
            return View(data);
        }
        [HttpPost]
        public ActionResult Issue(Models.BookIssueReturnModel bookIssueReturnModel)
        {
            bookIssueReturnModel.IssueDate = DateTime.Now;
            bookIssueReturnModel.DueDate = DateTime.Now.AddDays(15);
            bookIssueReturnModel.Status = 1;
           // bookIssueReturnModel.NoOfIssuedBook = bookIssueReturnService
               //     .DisplayDataByMemberId(bookIssueReturnModel.MemberID).Count;
            if (bookIssueReturnModel.NoOfIssuedBook < 3)
            {
                bookIssueReturnService.SaveData(bookIssueReturnModel);
                assessionMappingService.UpdateBookStatus((int)bookIssueReturnModel.AssessionID, 1);

                ViewBag.ResultMessage = "Issued Successfully";

            }
            else
            {
                ViewBag.ResultMessage = "You cannot Issue More then 3 books";

            }

            var dataMember = new MemberModel();
            dataMember = LoadModel((int)bookIssueReturnModel.MemberID);

            return RedirectToAction("Search", new { MemberID=dataMember.MemberID });

        }

        //[HttpGet]
        //public ActionResult Search()
        //{
        //    return View("_SearchPartial", new MemberModel());
        //}
        [HttpGet]
        public ActionResult Search(MemberModel model)
        {
            model = LoadModel(model.MemberID);

            return View("Index", model);
        }



        public ActionResult Issue()
        {
            return View("_IssueBook", new BookModel());
        }


        public ActionResult Edit(int id, int memberID)
        {
            bookIssueReturnService.UpdateReturnBookData(id, memberID);
            assessionMappingService.UpdateBookStatus(id, 0);

            return View("Index", LoadModel(memberID));
        }
       
        private MemberModel LoadModel(int MemberId)
        {
            MemberModel model = new MemberModel();
            model = memberService.GetData(MemberId);
            // model.MemberName = mem;
            model.ToIssueBookModel = new BookModel();
            model.ToIssueBookModel.MemberId = model.MemberID;
            model.ToIssueBookModel.BookIssueList = bookService.DisplayDataComboList();
            model.IssuedBookList = bookIssueReturnService.DisplayDataByMemberId(model.MemberID);
            //to count Issued no of books
            if (model.IssuedBookList != null)
            {
                model.ToIssueBookModel.NoOfIssuedBook = model.IssuedBookList.Count;
                model.NoOfIssuedBook = model.IssuedBookList.Count;
            }
            else
            {
                model.ToIssueBookModel.NoOfIssuedBook = 0;
                model.NoOfIssuedBook = 0;
            }
            model.ToIssueBookModel.MemberId = model.MemberID;

            return model;

        }
    }
}