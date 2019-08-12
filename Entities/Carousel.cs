namespace Entities
{
    public class Carousel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Url { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
