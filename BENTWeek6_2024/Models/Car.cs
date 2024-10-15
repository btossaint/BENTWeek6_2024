using BENTWeek6_2024.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENTWeek6_2024.Models
{
    internal class Car: Vehicle
    {
        public int NumberOfDoors { get; set; }
        public int NumberOfWheels { get; set; }
        public string TransmissionType { get; set; }

        public Car(string make, string model, int year, string color, 
            string licensePlate, int numberOfDoors, int numberOfWheels,
            string transmissionType)
            : base(make, model, year, color, licensePlate)
        {
            NumberOfDoors = numberOfDoors;
            NumberOfWheels = numberOfWheels;
            TransmissionType = transmissionType;
        }

        public override string Drive()
        {
            return $"The car {Make}-{Model} drives";
        }

        public override string Start()
        {
            return $"The car {Make}-{Model} startes";
        }
    }
}
