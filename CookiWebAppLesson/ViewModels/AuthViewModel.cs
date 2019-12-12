using System.ComponentModel.DataAnnotations;

namespace CookiWebAppLesson.ViewModels
{
    public class AuthViewModel
    {
        [EmailAddress(ErrorMessage ="Введен некоректный email")]
        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [MinLength(6)]
        [Required]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}
