using System.Collections.Generic;

namespace Entities
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EventCategoryEvent> EventCategoryEvent { get; set; }
    }
}
