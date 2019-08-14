using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Campus> Campuses { get; set; }
        public ICollection<Carousel> Carousels { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<EventCategory> EventCategories { get; set; }
        public ICollection<NewsCategory> NewsCategories { get; set; }
        public ICollection<MenuElement> MenuElements { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Staff> Staff { get; set; }

    }
}
