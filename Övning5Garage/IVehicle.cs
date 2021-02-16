namespace Övning5Garage
{
    public interface IVehicle
    {
        string Color { get; set; }
        int NumOfWheels { get; set; }
        string RegNo { get; set; }

        string ToString();
    }
}