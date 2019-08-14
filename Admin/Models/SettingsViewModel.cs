using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class SettingsViewModel
    {
        [Display(Name = "Ayar No")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int Id { get; set; }
        [Display(Name = "Site Başlığı")]
        [MaxLength(100)]
        public string SiteTitle { get; set; }
        [Display(Name = "Site Açıklama")]
        [MaxLength(4000)]
        public string SiteDescription { get; set; }
        [Display(Name = "Site Etiketler")]
        [MaxLength(100)]
        public string SiteTags { get; set; }

        [Display(Name = "Telefon No")]
        [DataType(DataType.PhoneNumber)]
        public string GeneralTelephone { get; set; }
        [Display(Name = "Adres")]
        [MaxLength(500)]
        public string GeneralAddress { get; set; }
        [Display(Name = "Eposta Adresi")]
        [DataType(DataType.EmailAddress)]
        public string GeneralEmailAddress { get; set; }
        [Display(Name = "Facebook")]
        [MaxLength(500)]
        public string FacebookUrl { get; set; }
        [Display(Name = "Twitter")]
        [MaxLength(500)]
        public string TwitterUrl { get; set; }
        [Display(Name = "Instagram")]
        [MaxLength(500)]
        public string InstagramUrl { get; set; }
        [Display(Name = "Youtube")]
        [MaxLength(500)]
        public string YouTubeUrl { get; set; }

    }
}
