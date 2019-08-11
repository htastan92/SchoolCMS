namespace Entities
{
    public class NewsCategoryNews
    {
        public int NewsId { get; set; }
        public News News { get; set; }

        public int NewsCategoryId { get; set; }
        public NewsCategory NewsCategory { get; set; }
    }
}
