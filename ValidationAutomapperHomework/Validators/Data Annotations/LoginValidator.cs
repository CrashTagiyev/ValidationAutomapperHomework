using System.ComponentModel.DataAnnotations;
namespace ValidationAutomapperHomework.Validators.Data_Annotations
{
    public class LoginValidator
    {
        [Required(ErrorMessage ="This input cannot be empty")]
        [MinLength(3 ,ErrorMessage ="Minimum 3 letter")]
        [MaxLength(16,ErrorMessage ="Maximum 16 letter")]
        public string? Username { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(16)]
        public string? Password { get; set; }
    }
}
