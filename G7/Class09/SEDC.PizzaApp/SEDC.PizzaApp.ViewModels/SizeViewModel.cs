using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.ViewModels
{
    public class SizeViewModel
    {
        public int Id { get; set; }
        //We can use Data Annotations for vaalidation
        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }
        //We can enter a custom Error Message or leave it as default for a specic requirement
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
