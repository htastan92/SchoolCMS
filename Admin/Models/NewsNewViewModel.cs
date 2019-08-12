using Entities;

namespace Admin.Models
{
    public class NewsNewViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string EditorContent { get; set; }

        public Status Status { get; set; }

        public Image Image { get; set; }
        

    }
}
