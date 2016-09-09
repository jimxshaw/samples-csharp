using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Globalization.Models
{
    public class Demo
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Age")]
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
    }
}