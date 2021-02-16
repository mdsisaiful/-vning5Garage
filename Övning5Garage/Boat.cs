using System;
using System.Collections.Generic;
using System.Text;

namespace Övning5Garage
{
    class Boat : Vehicle
    {
        public int LengthOfBoat { get; set; }

        public Boat(string regNo, string color, int numOfWheels, int lengthOfBoat) : base(regNo, color, numOfWheels)
        {
            LengthOfBoat = lengthOfBoat;
        }

        public override string ToString()
        {
            return $"{base.ToString()} and boat length: {LengthOfBoat}";
        }
    }
}
