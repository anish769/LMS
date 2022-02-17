using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Models
{
    public class BookModel
    {
        public int AssessionID { get; set; }
        public int MemberId { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public Nullable<int> BookCategoryID { get; set; }
        public Nullable<int> AuthorID { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public string Remarks { get; set; }
        public List<SelectListItem> BookIssueList { get; set; }
        public int NoOfIssuedBook { get; set; }

    }
}