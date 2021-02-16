using System;
using System.Collections.Generic;
using System.Text;

namespace Övning5Garage
{
    class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string regNo, string color, int numOfWheels, string fuelType) : base(regNo, color, numOfWheels)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return $"{base.ToString()} and fuel type: {FuelType}";
        }
    }
}
