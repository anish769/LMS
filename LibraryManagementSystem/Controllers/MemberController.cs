using LibraryManagementSystem.Models;
using LibraryManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class MemberController : Controller
    {
        MemberService memberService;
        public MemberController()
        {
            memberService = new MemberService();
        }
        // GET: Member
        public ActionResult Index()
        {
            var data = memberService.DisplayData();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Models.MemberModel memberModel)
        {
            memberService.SaveData(memberModel);
            var data = memberService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = memberService.GetData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(MemberModel model)
        {
            memberService.UpdateData(model);
            var dataList = memberService.DisplayData();
            return View("DisplayList", dataList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            memberService.DeleteData(id);
            var dataList = memberService.DisplayData();
            return View("DisplayList", dataList);
        }
        public ActionResult _DisplayPartialData()
        {
            var dataList = memberService.DisplayData();
            return View(dataList);
        }
    }
}