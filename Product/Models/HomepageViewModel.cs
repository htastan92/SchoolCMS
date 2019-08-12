using System.Collections.Generic;
using Entities;

namespace Product.Models
{
    public class HomepageViewModel
    {
        public IList<Carousel> Carousels { get; set; }
        public IList<Event> UpcomingEvents { get; set; }
        public IList<Review> Reviews { get; set; }
        public IList<News> LastNews { get; set; }
    }
}
