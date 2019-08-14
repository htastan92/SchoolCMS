using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Kullanıcı Adı")]
        [MaxLength(50)]
        public string UserName  { get; set; }
        [Display(Name = "Eski Şifre")]
        [DataType(DataType.Password)]
        public string OldPassword  { get; set; }
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string Password  { get; set; }
        [Display(Name = "Şifre Doğrulama")]
        [DataType(DataType.Password)]
        public string ConfirmPassword  { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(100)]
        [Display(Name = "Eposta Adresi")]
        [DataType(DataType.EmailAddress)]
        public string Email  { get; set; }
    }
}
