using System;
using System.Collections.Generic;
using System.Linq;

namespace Övning5Garage
{
    internal class GarageHandler
    {
        public IUI ui;
        public Garage<Vehicle> garage;
        public int count = 0;

        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
            ui = new UI();
            count = TotalVehicles();
        }


        public Garage<Vehicle> Garage { get; }

       
        public bool CheckForNull(Vehicle[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    return false;
                }
            }
            return true;
        }


        public void TotalParkedVehicles(int vItem, string vType)
        {

            if (vItem > 0)
            {
                ui.Print($"In Garage has: {vItem}, and {vType}");
            }
        }

        private int TotalVehicles()
        {
            var vList = garage.Vehicles;
            for (int i = 0; i < vList.Length; i++)
            {
                if (vList[i] != null)
                {
                    count++;
                }
            }
            return count;
        }

        internal IEnumerable<Vehicle> GetTotalVehicles()
        {
            return garage.ToList();
        }
    }
}