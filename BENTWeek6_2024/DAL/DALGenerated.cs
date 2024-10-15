using BENTWeek6_2024.Models;

namespace BENTWeek6_2024.DAL
{
    internal class DALGenerated
    {
        public List<Vehicle> GetAllVehicle()
        {
            // Get data from program.cs
            Car car1 = new Car("Toyota", "Corolla", 2003, "White", "ABC123", 4, 4, "Automatic");
            Car car2 = new Car("Honda", "Civic", 2010, "Red", "DEF456", 4, 4, "Manual");
            Car car3 = new Car("Ford", "Mustang", 2020, "Blue", "GHI789", 2, 4, "Automatic");
            Motorcycle motorcycle1 = new Motorcycle("Honda", "Wave", 2019, "Black", "XYZ123", 0, 2);
            Motorcycle motorcycle2 = new Motorcycle("Yamaha", "Mio", 2013, "Yellow", "UVW456", 1, 2);
            Motorcycle motorcycle3 = new Motorcycle("Suzuki", "Raider", 1999, "Green", "STU789", 0, 2);

            // Fille list with vehicles
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(car1);
            vehicles.Add(car2);
            vehicles.Add(car3);
            vehicles.Add(motorcycle1);
            vehicles.Add(motorcycle2);
            vehicles.Add(motorcycle3);

            return vehicles;
        }
    }
}
