using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Admin.Models
{
    public class CampusEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Kampüs Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Url")]
        [MaxLength(200)]
        public string Slug { get; set; }

        [MaxLength(120)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "İçerik")]
        [DataType(DataType.Html)]
        public string EditorContent { get; set; }

        [Display(Name = "Durum")]
        [Required]
        public int StatusId { get; set; }

        [Display(Name = "Resim Url")]
        [MaxLength(200)]
        public IList<IFormFile> Photos { get; set; }

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
