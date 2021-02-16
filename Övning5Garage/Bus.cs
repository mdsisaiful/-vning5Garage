using System;
using System.Collections.Generic;
using System.Text;

namespace Övning5Garage
{
    class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string regNo, string color, int numOfWheels, int numberOfSeats) : base(regNo, color, numOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{base.ToString()} and number of seats: {NumberOfSeats}";
        }
    }
}
