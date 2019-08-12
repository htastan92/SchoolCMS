namespace Admin.Models
{
    public class StaffEditViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Sector { get; set; }
        public string BioText { get; set; }
        public int StatusId { get; set; }
        public int CampusId { get; set; }
    }
}
