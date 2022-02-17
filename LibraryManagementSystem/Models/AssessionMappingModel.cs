using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class AssessionMappingModel
    {
        public int AssessionID { get; set; }
        public Nullable<int> BookID { get; set; }
        public Nullable<byte> Status { get; set; }
    }
}