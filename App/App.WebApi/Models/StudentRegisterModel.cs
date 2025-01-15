using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.WebApi.Models
{
    public class StudentRegisterModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        
        public string Surname { get; set; }
        [Required]
        [Range(1, 100)]

        public int StudentIdNumber { get; set; }

        [Required]
        [RegularExpression(@"^[A-E]$", ErrorMessage = "Class must be between A and E.")]
        public string Class {  get; set; }


        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Range(typeof(DateTime), "1900-01-01", "2024-12-31")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Adress { get; set; }

        [Required]
        [MinLength(4)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,24}$")] //Parola için kullanılan REGEX
        public string Password { get; set; }

        [Required]
        //[Compare("Password")]
        [Compare(nameof(Password))] //nameof daha kesin bir yöntem
        public string PasswordRepeat { get; set; }
    }
}
