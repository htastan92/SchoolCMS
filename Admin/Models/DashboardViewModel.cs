using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class DashboardViewModel
    {
        [Display(Name = "Kampüs Sayısı")]
        public int CampusCount { get; set; }
        [Display(Name = "Etkinlik Sayısı")]
        public int EventCount { get; set; }
        [Display(Name = "Üye Sayısı")]
        public int MemberCount { get; set; }
        [Display(Name = "Menü Elemanı Sayısı")]
        public int MenuElementCount { get; set; }
        [Display(Name = "Haber Sayısı")]
        public int NewsCount { get; set; }
        [Display(Name = "Sayfa Sayısı")]
        public int PageCount { get; set; }
        [Display(Name = "Eğitmen Sayısı")]
        public int StaffCount { get; set; }
        [Display(Name = "Talep Sayısı")]
        public int FormCount { get; set; }
    }
}
