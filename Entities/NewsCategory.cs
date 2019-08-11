using System.Collections.Generic;

namespace Entities
{
    public class NewsCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NewsCategoryNews> NewsCategoryNews { get; set; }
    }
}
