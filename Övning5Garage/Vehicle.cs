namespace Övning5Garage
{
    public class Vehicle : IVehicle
    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public int NumOfWheels { get; set; }

        public Vehicle(string regNo, string color, int numOfWheels)
        {
            RegNo = regNo;
            Color = color;
            NumOfWheels = numOfWheels;
        }

        public override string ToString()
        {
            return $"Vehicle type: {this.GetType().Name}, registration number: {RegNo}, color: {Color}, number of wheels: {NumOfWheels}";
        }
    }
}