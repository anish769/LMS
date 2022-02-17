using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class FineModel
    {
        public int FineID { get; set; }
        public Nullable<int> LateDays { get; set; }
        public Nullable<int> MemberCategoryID { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Remarks { get; set; }
    }
}