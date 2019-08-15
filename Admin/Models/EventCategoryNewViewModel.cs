using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class EventCategoryNewViewModel
    {
        [Display(Name = "Etkinlik Kategori Adı")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Display(Name = "Durum")]
        [Required]
        public int StatusId { get; set; }
    }
}
