using BENTWeek6_2024.Models;

namespace BENTWeek6_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get vehicles // false -> No database connection // true -> Database connection
            Vehicle vehicle = new Vehicle();
            List<Vehicle> vehicles = vehicle.GetAllVehicles(true);

            Car car1 = new Car("Hyundai", "Tucson", 2022, "Red", "ABC123", 4, 4, "Automatic");
            Car car2 = new Car("Renault", "Clio", 2023, "White", "DEF456", 4, 4, "Manual");
            Motorcycle motorcycle1 = new Motorcycle("Harley Davidson", "R4", 2019, "Black", "XYZ123", 0, 2);

            car1.AddVehicle();
            car2.AddVehicle();
            motorcycle1.AddVehicle();
            
            // Loop through list and print out the vehicle's drive and start methods
            foreach (Vehicle v in vehicles)
            {
                Console.WriteLine(v.Start());
                Console.WriteLine(v.Drive());
            }
            Console.WriteLine($"Vehicles count: {vehicles.Count()}");
        }
    }
}




