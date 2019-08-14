using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public ICollection<Carousel> Carousels { get; set; }
        public ICollection<Campus> Campuses { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}