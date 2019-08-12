namespace Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
