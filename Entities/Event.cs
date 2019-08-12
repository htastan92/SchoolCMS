using System;
using System.Collections.Generic;

namespace Entities
{
    public class Event : Content
    {
        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public ICollection<EventCategoryEvent> EventCategoryEvent { get; set; }
    }
}
