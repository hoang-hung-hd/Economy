using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Economy.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
