using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class ContactViewModel
    {
        [Display(Name = "Veli Adı Soyadı")]
        [MaxLength(100)]
        [Required]
        public string ParentFullName { get; set; }
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Posta Adresi")]
        public string EmailAddress { get; set; }
        [MaxLength(100)]
        [Required]
        [Display(Name = "Öğrenci Adı Soyadı")]
        public string StudentFullName { get; set; }
        [Display(Name = "Kampüs")]
        [Required]
        public int CampusId { get; set; }
    }
}
