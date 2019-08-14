using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class PageEditViewModel
    {
        [Display(Name = "Sayfa No")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int Id { get; set; }
        [Display(Name = "Sayfa Adı")]
        [MaxLength(200)]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Name { get; set; }
        [MaxLength(200)]
        [Display(Name = "Url")]
        public string Slug { get; set; }
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        [MaxLength(4000)]
        public string Description { get; set; }
        [Display(Name = "İçerik")]
        [MaxLength(500)]
        public string EditorContent { get; set; }
        [Display(Name = "Durum")]
        public int StatusId { get; set; }
        [Display(Name = "Resim")]
        public int ImageId { get; set; }
    }
}
