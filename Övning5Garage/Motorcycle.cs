using System;
using System.Collections.Generic;
using System.Text;

namespace Övning5Garage
{
    class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }

        public Motorcycle(string regNo, string color, int numOfWheels, int cylinderVolume) : base(regNo, color, numOfWheels)
        { 
             CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return $"{base.ToString()} and Cylinder volume: {CylinderVolume}";
        }


    }
}
