using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BookIssueReturnModel
    {
        public int BookIssueReturnID { get; set; }
        public string BookDescription { get; set; }
        public Nullable<int> MemberID { get; set; }
        public Nullable<int> AssessionID { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<int> LateDays { get; set; }
        public Nullable<int> FineAmount { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<int> StaffMemberID { get; set; }
        public string Remarks { get; set; }
        public int NoOfIssuedBook { get; set; }
        public string ResultString { get; set; }


    }
}