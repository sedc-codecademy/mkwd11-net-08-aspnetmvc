using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public CarsManufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public FuelType FuelType { get; set; }
        [Display(Name = "Number of doors")]
        public int NumberOfDoors { get; set; }
    }
}
