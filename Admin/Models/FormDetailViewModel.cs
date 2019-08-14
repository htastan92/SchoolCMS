using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class FormDetailViewModel
    {
        [Display(Name = "Veli Adı-Soyadı")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string ParentFullName { get; set; }
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Eposta Adresi")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Display(Name = "Öğrenci Adı-Soyadı")]
        [MaxLength(100)]
        public string StudentFullName { get; set; }
        [Display(Name = "Kampüs")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int CampusId { get; set; }
        
    }
}
