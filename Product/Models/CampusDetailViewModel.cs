using System.Collections.Generic;
using Entities;

namespace Product.Models
{
    public class CampusDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EditorContent { get; set; }
        public string ImageUrl { get; set; }

        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }

        public IList<Staff> Staff { get; set; }
        public IList<Event> Events { get; set; }
        public IList<News> News { get; set; }
    }
}
