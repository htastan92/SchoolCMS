using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Admin.Models
{
    public class CarouselNewViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Url { get; set; }
        public IList<IFormFile> Photos { get; set; }
        public int StatusId { get; set; }
        public IList<Status> Statuses { get; set; }
    }
}
