using System;
using Xunit;    //xUnit Nuget package

namespace Övning5Garage.GarageTest
{
    public class GarageTests
    {
        public Garage<Vehicle> garage = new Garage<Vehicle>(0);
       
        
        [Fact] // this attribute to tell you what passed or failed in the test
        public void CountVehiclesTest()
        {
            // arrange section

            const int expected = 0;

            // act section

            var actual = garage.Capacity;

            // assert section

            Assert.Equal(expected, actual);
        }
    }
}
