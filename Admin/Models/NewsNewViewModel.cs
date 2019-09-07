using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Admin.Models
{
    public class NewsNewViewModel
    {
        [Display(Name = "Haber Adı")]
        [MaxLength(200)]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Name { get; set; }

        [Display(Name = "Url")]
        [MaxLength(200)]
        public string Slug { get; set; }

        [Display(Name = "Açıklama")]
        [MaxLength(120)]
        public string Description { get; set; }

        [Display(Name = "İçerik")]
        [DataType(DataType.Html)]
        public string EditorContent { get; set; }

        [Display(Name = "Durum")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int StatusId { get; set; }

        [Display(Name = "Resim")]
        public IList<IFormFile> Photos { get; set; }

        [Display(Name = "Kampüs")]
        public int CampusId { get; set; }
    }
}
