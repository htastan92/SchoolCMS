using System;

namespace Entities
{
    public class Event : Content
    {
        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Campus Campus { get; set; }
    }
}
