using System.Collections.Generic;

namespace Entities
{
    public class News : Content
    {
        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public ICollection<NewsCategoryNews> NewsCategoryNews { get; set; }
    }
}
