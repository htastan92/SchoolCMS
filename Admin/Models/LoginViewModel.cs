using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
