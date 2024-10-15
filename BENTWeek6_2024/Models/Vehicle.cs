using BENTWeek6_2024.DAL;

namespace BENTWeek6_2024.Models
{
    internal class Vehicle
    {
        private SQLDAL sqlDAL = SQLDAL.Instance;
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }

        public Vehicle()
        {
            
        }

        public Vehicle(string make, string model, int year,
            string color, string licensePlate)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            LicensePlate = licensePlate;            
        }

        public virtual string Drive()
        {
            return $"The vehicle {Make}-{Model} drives";
        }

        public virtual string Start()
        {
            return $"The vehicle {Make}-{Model} startes";
        }

        /// <summary>
        /// Get all vehicles from the database
        /// </summary>
        /// <param name="_db">true = Database / false = no database</param>
        /// <returns></returns>
        public List<Vehicle> GetAllVehicles(bool _db)
        {
            if (_db)
            {
                return sqlDAL.GetAllVehicle();
            }
            else
            {
                DALGenerated dalGenerated = new DALGenerated();
                return dalGenerated.GetAllVehicle();
            }
        }

        public List<Vehicle> AddVehicle()
        {
            return sqlDAL.AddVehicle(this);
        }
    }
}
