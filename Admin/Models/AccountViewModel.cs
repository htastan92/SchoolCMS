using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class AccountViewModel
    {
        public string UserName  { get; set; }

        [DataType(DataType.Password)]
        public string OldPassword  { get; set; }

        [DataType(DataType.Password)]
        public string Password  { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword  { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email  { get; set; }
    }
}
