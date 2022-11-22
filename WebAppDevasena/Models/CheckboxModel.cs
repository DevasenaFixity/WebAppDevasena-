using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebAppDevasena.Models
{
    public class CheckboxModel
    {

        [Required(ErrorMessage = "Enter ROLLNO")]
        public string ROLLNO { get; set; }

        [Required(ErrorMessage = "What's ur Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string NAME { get; set; }

        [Required(ErrorMessage = "QUALIFICATION is required")]
        public bool QUALIFICATION { get; set; }
        public bool QUALIFICATION1 { get; set; }
        public bool QUALIFICATION2 { get; set; }
    }
}
