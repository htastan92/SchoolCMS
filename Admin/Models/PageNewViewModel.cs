using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class PageNewViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string EditorContent { get; set; }

        public int StatusId { get; set; }
        public int ImageId { get; set; }
    }
    }
}
