namespace Entities
{
    public class EventCategoryEvent
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
    }
}
