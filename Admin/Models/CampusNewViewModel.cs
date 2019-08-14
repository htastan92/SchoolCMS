using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class CampusNewViewModel
    {
        [Display(Name = "Kampüs Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Display(Name = "Url")]
        [MaxLength(200)]
        public string Slug { get; set; }
        [MaxLength(4000)]
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [MaxLength(500)]
        [Display(Name = "İçerik")]
        public string EditorContent { get; set; }
        [Display(Name = "Durum")]
        [Required]
        public int StatusId { get; set; }
        [Display(Name = "Resim Url")]
        [MaxLength(200)]
        public string ImageUrl { get; set; }
        [MaxLength(500)]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        public string Telephone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fax Numarası")]
        public string Fax { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Eposta Adresi")]
        public string EmailAddress { get; set; }
    }
}
