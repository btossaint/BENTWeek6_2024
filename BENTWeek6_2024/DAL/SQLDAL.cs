using BENTWeek6_2024.Models;
using System.Data.SqlClient;

namespace BENTWeek6_2024.DAL
{
    internal class SQLDAL
    {
        private static SQLDAL instance;
        private SqlConnection connection;
        private string connectionString;
        private List<Vehicle> vehicles;

        private SQLDAL()
        {
            vehicles = new List<Vehicle>();
            connectionString = "Data Source=.;Initial Catalog=BENTGarage; Trusted_Connection=True";
            // Create a new SqlConnection object
            connection = new SqlConnection(connectionString);
        }

        public static SQLDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLDAL();
                }
                return instance;
            }
        }

        public List<Vehicle> GetAllVehicle()
        {
            // clear the list of vehicles
            vehicles.Clear();
            // Get new data from database

            string query = "SELECT * FROM Vehicle";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string make = reader["Make"].ToString();
                string model = reader["Model"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                string color = reader["Color"].ToString();
                string licensePlate = reader["LicensePlate"].ToString();
                string vehicleType = reader["VehicleType"].ToString();

                if (vehicleType == 'C'.ToString())
                {
                    int numberOfDoors = Convert.ToInt32(reader["NumberOfDoors"]);
                    int numberOfWheels = Convert.ToInt32(reader["NumberOfWheels"]);
                    string transmissionType = reader["TransmissionType"].ToString();

                    Car car = new Car(make, model, year, color, licensePlate, numberOfDoors, numberOfWheels, transmissionType);
                    vehicles.Add(car);
                }
                else if (vehicleType == 'M'.ToString())
                {
                    int engineDisplacement = Convert.ToInt32(reader["EngineDisplacement"]);
                    int numberOfWheels = Convert.ToInt32(reader["NumberOfWheels"]);

                    Motorcycle motorcycle = new Motorcycle(make, model, year, color, licensePlate, engineDisplacement, numberOfWheels);
                    vehicles.Add(motorcycle);
                }
            }

            reader.Close();

            // return the list of vehicles now in the database
            return vehicles;
        }

        public List<Vehicle> AddVehicle(Vehicle vehicle)
        {
            if (vehicle.GetType() == typeof(Car))
            {
                AddCar(vehicle as Car);
            }
            else if (vehicle.GetType() == typeof(Motorcycle))
            {
                AddMotorcycle(vehicle as Motorcycle);
            }
            return vehicles;
        }

        private List<Vehicle> AddCar(Car vehicle)
        {
            // Add vehicle to database

            string query = "INSERT INTO Vehicle (Make, Model, Year, Color, LicensePlate, NumberOfDoors, NumberOfWheels, TransmissionType, VehicleType) " +
                "VALUES (@Make, @Model, @Year, @Color, @LicensePlate, @NumberOfDoors, @NumberOfWheels, @TransmissionType, @VehicleType)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Make", vehicle.Make);
            command.Parameters.AddWithValue("@Model", vehicle.Model);
            command.Parameters.AddWithValue("@Year", vehicle.Year);
            command.Parameters.AddWithValue("@Color", vehicle.Color);
            command.Parameters.AddWithValue("@LicensePlate", vehicle.LicensePlate);
            command.Parameters.AddWithValue("@NumberOfDoors", vehicle.NumberOfDoors);
            command.Parameters.AddWithValue("@NumberOfWheels", vehicle.NumberOfWheels);
            command.Parameters.AddWithValue("@TransmissionType", vehicle.TransmissionType);
            command.Parameters.AddWithValue("@VehicleType", 'C');

            //connection.Open();
            command.ExecuteNonQuery();

            vehicles.Add(vehicle);
            return vehicles;
        }

        private List<Vehicle> AddMotorcycle(Motorcycle vehicle)
        {
            // Add vehicle to database

            string query = "INSERT INTO Vehicle (Make, Model, Year, Color, LicensePlate, EngineDisplacement, NumberOfWheels, VehicleType) " +
                "VALUES (@Make, @Model, @Year, @Color, @LicensePlate, @EngineDisplacement, @NumberOfWheels, @VehicleType)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Make", vehicle.Make);
            command.Parameters.AddWithValue("@Model", vehicle.Model);
            command.Parameters.AddWithValue("@Year", vehicle.Year);
            command.Parameters.AddWithValue("@Color", vehicle.Color);
            command.Parameters.AddWithValue("@LicensePlate", vehicle.LicensePlate);
            command.Parameters.AddWithValue("@EngineDisplacement", vehicle.EngineDisplacement);
            command.Parameters.AddWithValue("@NumberOfWheels", vehicle.NumberOfWheels);
            command.Parameters.AddWithValue("@VehicleType", 'M');

            //connection.Open();
            command.ExecuteNonQuery();

            vehicles.Add(vehicle);
            return vehicles;
        }
    }
}
