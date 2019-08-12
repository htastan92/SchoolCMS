namespace Product.Models
{
    public class PageDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string EditorContent { get; set; }

        public string ImageUrl { get; set; }
    }
}
