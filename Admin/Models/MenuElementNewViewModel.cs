using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class MenuElementNewViewModel
    {
        [Display(Name = "Menü Element Adı")]
        public string Name { get; set; }
        public string Url { get; set; }
        [Display(Name = "Menü Konumu")]
        public int MenuLocation { get; set; }
        [Display(Name = "Üst Menü Adı")]
        public int ParentMenuId { get; set; }
        [Display(Name = "Durum")]
        public int StatusId { get; set; }

    }
}
