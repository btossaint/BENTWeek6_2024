using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENTWeek6_2024.Models
{
    internal class Motorcycle : Vehicle
    {        
        public int EngineDisplacement { get; set; }
        public int NumberOfWheels { get; set; }        

        public Motorcycle(string make, string model, int year, string color, 
            string licensePlate, int engineDisplacement, int numberOfWheels)
            : base(make, model, year, color, licensePlate)
        {
            EngineDisplacement = engineDisplacement;
            NumberOfWheels = numberOfWheels;
        }

        public override string Drive()
        {
            return $"The motorcycle {Make}-{Model} drives";
        }

        public override string Start()
        {
            return $"The motorcycle {Make}-{Model} startes";
        }
    }
}
