using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class StaffNewViewModel
    {
        [Display(Name = "Eğitmen Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Display(Name = "Branş")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Sector { get; set; }

        [Display(Name = "Eğitmen Hakkında")]
        public string BioText { get; set; }

        [Display(Name = "Durum")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int StatusId { get; set; }

        [Display(Name = "Kampüs")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int CampusId { get; set; }
    }
}
