using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Models
{
    public class SizeViewModel
    {
        public int Id { get; set; }
        //We can use Data Annotations for vaalidation
        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }
        //We can enter a custom Error Message or leave it as default for a specic requirement
        [Required]
        public string Description { get; set; }
    }
}
