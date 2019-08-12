using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class DashboardViewModel
    {
        public int CampusCount { get; set; }
        public int EventCount { get; set; }
        public int MemberCount { get; set; }
        public int MenuElementCount { get; set; }
        public int NewsCount { get; set; }
        public int PageCount { get; set; }
        public int StaffCount { get; set; }
        public int FormCount { get; set; }
    }
}
