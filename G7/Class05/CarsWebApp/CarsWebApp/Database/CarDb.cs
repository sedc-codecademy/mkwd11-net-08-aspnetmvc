using CarsWebApp.Models;

namespace CarsWebApp.Database
{
    public static class CarDb
    {
        public static List<Car> Cars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Manufacturer = CarsManufacturer.Renault,
                Model = "Megane",
                FuelType = FuelType.Petrol,
                NumberOfDoors = 3
            },
            new Car
            {
                Id = 2,
                Manufacturer = CarsManufacturer.Mercedes,
                Model = "E200",
                FuelType = FuelType.Diesel,
                NumberOfDoors = 5
            },
            new Car
            {
                Id = 3,
                Manufacturer = CarsManufacturer.Audi,
                Model = "Q5",
                FuelType = FuelType.Hybrid,
                NumberOfDoors = 5
            },
        };
    }
}
