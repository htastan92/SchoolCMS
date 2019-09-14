using System;
using System.Collections.Generic;
using Entities;

namespace Product.Models
{
    public class EventDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EditorContent { get; set; }
        public string ImageUrl { get; set; }
        public string Slug { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CampusId { get; set; }

        public ICollection<EventCategory> Categories { get; set; }
    }
}
