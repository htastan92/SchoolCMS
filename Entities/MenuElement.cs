namespace Entities
{
    public class MenuElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int MenuLocation { get; set; }

        public int ParentMenuId { get; set; }
        public MenuElement ParentMenu { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
