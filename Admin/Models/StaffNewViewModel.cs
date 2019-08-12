using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models
{
    public class StaffNewViewModel
    {
        public string FullName { get; set; }
        public string Sector { get; set; }
        public string BioText { get; set; }
        public Status Status { get; set; }
        public Campus Campus { get; set; }
    }
}
