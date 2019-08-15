using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class EventCategoryEditViewModel
    {
        [Display(Name = "Etkinlik Kategori No")]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Etkinlik Kategori Adı")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Display(Name = "Durum")]
        [Required]
        public int StatusId { get; set; }
    }
}
