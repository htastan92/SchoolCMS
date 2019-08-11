namespace Entities
{
    public class Staff
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Sector { get; set; }
        public string BioText { get; set; }
        public Status Status { get; set; }
        public Campus Campus { get; set; }
    }
}
