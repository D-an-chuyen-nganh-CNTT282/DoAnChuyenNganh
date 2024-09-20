using System.ComponentModel.DataAnnotations;

namespace QLHV_BackEnd.Model
{
    public class UserModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email {  get; set; }
        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string? Password { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string? PasswordHash { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }

    }
}
