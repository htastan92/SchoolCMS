using System.Collections.Generic;

namespace Entities
{
    public class News : Content
    {
        public ICollection<NewsCategoryNews> NewsCategoryNews { get; set; }
    }
}
