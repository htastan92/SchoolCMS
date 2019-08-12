using System.Collections.Generic;
using Entities;

namespace Product.Models
{
    public class NewsDetailViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string EditorContent { get; set; }
        public string ImageUrl { get; set; }

        public IList<NewsCategory> Categories { get; set; }
    }
}
