using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Models
{
    public class MemberModel
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public int NoOfIssuedBook { get; set; }
        public Nullable<int> MemberCategoryID { get; set; }
        public string MemberAddress { get; set; }
        public Nullable<long> ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Remarks { get; set; }
        public Nullable<byte> Status { get; set; }
        public BookModel ToIssueBookModel { get; set; }
        public List<BookIssueReturnModel> IssuedBookList { get; set; }
    }
}