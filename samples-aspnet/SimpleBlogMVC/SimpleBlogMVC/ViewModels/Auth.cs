using System.ComponentModel.DataAnnotations;

namespace SimpleBlogMVC.ViewModels
{
    public class AuthLogin
    {
        // public string Test { get; set; }

        [Required]
        public string Username { get; set; }

        // Data annotations are attributes we apply to ViewModels to
        // change the behavior of how they appear in the views as
        // well as how they're validated.
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}