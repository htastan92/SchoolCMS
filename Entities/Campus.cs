using System.Collections.Generic;

namespace Entities
{
    public class Campus : Content
    {
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<Staff> Staff { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<News> News { get; set; }
    }
}
