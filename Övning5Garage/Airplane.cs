using System;
using System.Collections.Generic;
using System.Text;

namespace Övning5Garage
{
    class Airplane : Vehicle
    {
        public int NumOfEngines { get; set; }
        public Airplane(string regNo, string color, int numOfWheels, int numOfEngines) : base(regNo, color, numOfWheels)
        {
            NumOfEngines = numOfEngines;
        }

        public override string ToString()
        {
            return $"{base.ToString()} and number of engines: {NumOfEngines}";
        }
    }
}
