using System.ComponentModel.DataAnnotations;

namespace App.WebApi.Models
{
    public class StudentLoginModel
    {
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [MinLength(4)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,24}$")]
        public string Password { get; set; }
    }
}
