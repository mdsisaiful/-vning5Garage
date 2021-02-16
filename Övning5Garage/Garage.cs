using System;
using System.Collections;
using System.Collections.Generic;

namespace Övning5Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;
        private int count = 0;
        private int capacity;

        public int Count { get; set; }
        public int Capacity { get; set; }


        public T[] Vehicles
        {
            get { return vehicles; }
            set { vehicles = value; }
        }


        public bool IsFull
        {
            get
            {
                return capacity == count;
            }
        }


        public Garage(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            vehicles = new T[this.capacity];
        }


        // remove vehicle
        public bool Remove(T item)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == item)
                {
                    vehicles[i] = null;
                    Count--;
                    return true;
                }
            }
            return false;
        }


        // Add vehicle
        public bool Add(T item)
        {
            if (!IsFull && item != null)
            {
                vehicles[count] = item;
                Count++;
                return true;
            }
            return false;
        }


        // count vehicle
        public int CountVehicles()
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null)
                {
                    Count++;
                }
            }
            return Count;
        }



        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}

