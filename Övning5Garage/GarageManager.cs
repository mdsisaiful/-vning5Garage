using System;
using System.Collections.Generic;
using System.Linq;

namespace Övning5Garage
{
    public class GarageManager
    {
        private string regNo;
        private string color;
        private int numOfWheels;
        private int numOfEngines;
        private int cylinderVolume;
        private string fuelType;
        private int numberOfSeats;
        private int lengthOfBoat;


        private IUI ui;
        private GarageHandler garageHandler;

        public int Count = 0;

        public int Capacity { get; set; }

        public GarageManager()
        {
            ui = new UI();
        }

        public void Start()
        {
            CreateGarage();
            SeedData();
            MainMenu();
        }

        private void MainMenu()
        {
            while (true)
            {
                ui.Print("Please navigate through the menu by inputting " +
                    "the number \n(1, 2, 3 ,4, 5, 6, 0) of your choice"

                    + "\n1. Add Vehicle"
                    + "\n2. Remove Vehicle"
                    + "\n3. Display all parked Vehicles"
                    + "\n4. Display number of Vehicles"
                    + "\n5. Search Vehicle based on the registration number"
                    + "\n6. Search Vehicle based on the color, the number of wheels or types"
                    + "\n0. Exit the application");

                char input = ' ';
                try
                {
                    input = Console.ReadLine()[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    ui.Print("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        AddVehicleMenu();
                        break;
                    case '2':
                        RemoveVehicle();
                        break;
                    case '3':
                        DisplayParkedVehicles();
                        //$"The number of parked vehicles: {}";
                        break;
                    case '4':
                        DisplayNumberOfVehicles();
                        //$"The number of vehicles: {}";
                        break;
                    case '5':
                        SearchVechicleRegNo();
                        break;
                    case '6':
                        SearchVehicleProperties();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        ui.Print("Please enter some valid input (0, 1, 2, 3, 4, 5, 6)");
                        break;
                }
            }
        }

        private void SeedData()
        {
            garageHandler.garage.Add(new Airplane("SAS123", "Blue", numOfWheels: 9, numOfEngines: 4));
            garageHandler.garage.Add(new Motorcycle("STC12", "Black", numOfWheels: 2, cylinderVolume: 3));
            //garageHandler.garage.Add(new Car("Saab2", "Gray", numOfWheels: 4, "Octane"));
            //garageHandler.garage.Add(new Bus("UU12", "Red", numOfWheels: 6, numberOfSeats: 38));
            //garageHandler.garage.Add(new Boat("SWE3", "White", numOfWheels: 2, lengthOfBoat: 12));
        }

        private void CreateGarage()
        {
            int garageSize;
            bool isSizeOk = true;
            do
            {
                ui.Print("You are welcome to create a garage based on your needs!");
                garageSize = ui.AskForInt("The garage are occupied by 2 vehicles ..!!\n" +
                    "\n**please enter the garaze size based on your need: ");
                if (garageSize < 2)
                {
                    ui.Print("Require input more than 2!");
                }
                else
                {
                    isSizeOk = false;
                }

            } while (isSizeOk);

            garageHandler = new GarageHandler(garageSize);
        }

        private void SearchVehicleProperties()
        {
            var vList = garageHandler.garage.Vehicles;
            string inputType = "";
            string inputColor = "";
            int inputWheels = -1;
            var searchStr = "Please search vehicle through the menu by inputting " +
                    "the number \n(1, 2, 3 ,4, 0) of your choice "

                    + "\n1. Search by color"
                    + "\n2. Search by number of wheels"
                    + "\n3. Search by type";


            var userString = "Search?: ";
            var searchAgain = "Search again?: \n1. Yes \n2. No, display search result";

            bool isSearchOk = true;
            do
            {
                ui.Print(searchStr);
                string userInput = ui.GetInput();

                switch (userInput)
                {
                    case "1":
                        ui.Print(userString);
                        inputType = ui.GetInput();
                        ui.Print(searchAgain);
                        string againInput = ui.GetInput();
                        if (againInput == "1") continue;
                        if (againInput == "2") isSearchOk = false;
                        break;

                    case "2":
                        ui.Print(userString);
                        inputColor = ui.GetInput();
                        ui.Print(searchAgain);
                        againInput = ui.GetInput();
                        if (againInput == "1") continue;
                        if (againInput == "2") isSearchOk = false;
                        break;

                    case "3":
                        ui.Print(userString);
                        inputWheels = Convert.ToInt32(ui.GetInput());
                        ui.Print(searchAgain);
                        againInput = ui.GetInput();
                        if (againInput == "1") continue;
                        if (againInput == "2") isSearchOk = false;
                        break;

                    default:
                        ui.Print("Please enter some valid input (1, 2, 3)");
                        break;
                }

            } while (isSearchOk);

            if (garageHandler.CheckForNull(vList))
            {
                ui.Print("The vehicle was not found!");
            }
            else
            {
                var filter = vList.Where(ve => ve?.Color.ToLower().ToUpper() == inputColor.ToLower().ToUpper() || ve?.NumOfWheels == inputWheels || ve?.GetType().Name.ToUpper().ToLower() == inputType.ToUpper().ToLower());

                foreach (var item in filter)
                {
                    ui.Print($"Found {item.GetType().Name} with color {item.Color} and {item.NumOfWheels} wheels");
                }
            }


        }

        private void SearchVechicleRegNo()
        {
            var vList = garageHandler.garage.Vehicles;
            ui.Print("Please enter registeration number that you are looking for: ");
            regNo = ui.GetInput();
            for (int i = 0; i < vList.Length; i++)
            {
                if (vList[i] == null || vList[i].RegNo == regNo)
                {
                    ui.Print("Not found!");
                }
                else if (vList[i]?.RegNo.ToUpper() == regNo.ToUpper() || vList[i].RegNo?.ToLower() == regNo.ToLower())
                {
                    ui.Print($"{vList[i]} is found with {vList[i].GetType().Name}!");
                }
            }
        }

        private void DisplayNumberOfVehicles()
        {

            IEnumerable<Vehicle> totalVehicles = garageHandler.GetTotalVehicles();
            ui.Print("Total number of vehicles: ");
            foreach (var item in totalVehicles)
            {
                ui.Print(item.ToString());
            }
        }

        private void DisplayParkedVehicles()
        {
            int parkedAirplane = 0;
            int parkedMotorcycle = 0;
            int parkedCar = 0;
            int parkedBus = 0;
            int parkedBoat = 0;
            var vList = garageHandler.garage.Vehicles;
            var vehicles = new Garage<Vehicle>(Capacity);

            foreach (Vehicle item in vList)
            {
                if (item == null)
                {

                    ui.Print($"Parking place is empty");
                }
                else
                {
                    string baseString = $"{item.GetType().Name} has registration number {item.RegNo}, color {item.Color}, and {item.NumOfWheels} wheels";

                    if (item is Airplane)
                    {

                        var plane = item as Airplane;
                        parkedAirplane++;
                        ui.Print($"{baseString} {plane.NumOfEngines} engines");

                    }
                    if (item is Car)
                    {
                        var car = item as Car;
                        parkedCar++;
                        ui.Print($"{baseString} needs {car.FuelType}");
                    }

                    if (item is Motorcycle)
                    {
                        var motorcycle = item as Motorcycle;
                        parkedMotorcycle++;
                        ui.Print($"{baseString} has {motorcycle.CylinderVolume} cm cylinder");
                    }
                    if (item is Boat)
                    {
                        var boat = item as Boat;
                        parkedBoat++;
                        ui.Print($"{baseString} is {boat.LengthOfBoat} long");
                    }
                    if (item is Bus)
                    {
                        var bus = item as Bus;
                        parkedBus++;
                        ui.Print($"{baseString} has {bus.NumberOfSeats} seats");
                    }
                }

            }
            garageHandler.TotalParkedVehicles(parkedAirplane, "Airplane");
            garageHandler.TotalParkedVehicles(parkedMotorcycle, "Motorcycle");
            garageHandler.TotalParkedVehicles(parkedCar, "Car");
            garageHandler.TotalParkedVehicles(parkedBus, "Bus");
            garageHandler.TotalParkedVehicles(parkedBoat, "Boat");
            int garageVehicles = parkedAirplane + parkedCar + parkedMotorcycle + parkedBus + parkedBoat;
            ui.Print($"Total vehicles in the garage: {garageVehicles}");
            int availableParkingSpot = garageHandler.garage.Capacity - garageHandler.garage.Count;
            ui.Print($"Available parking spot: {availableParkingSpot}");
        }

        private void RemoveVehicle()
        {
            var removeV = garageHandler.garage.Vehicles;

            for (int i = 0; i < removeV.Length; i++)
            {
                if (removeV[i] != null)
                {
                    ui.Print($"{i}. {removeV[i].Color} {removeV[i].GetType().Name} with registration number {removeV[i].RegNo} and {removeV[i].NumOfWheels} wheels");
                }
            }
        }

        private void AddVehicleMenu()
        {

            bool success = true;
            ui.Print("Please add vehicle through the menu by inputting " +
                    "the number \n(1, 2, 3 ,4, 5, 6, 0) of your choice"

                    + "\n1. Add Airplane"
                    + "\n2. Add Motorcycle"
                    + "\n3. Add Car"
                    + "\n4. Add Bus"
                    + "\n5. Add Boat"
                    + "\n0. Exit the application");
            do
            {
                int input = ui.AskForInt("");

                switch (input)
                {
                    case 1:
                        AddAirPlane();
                        ui.Print("Airplane is successfully parked");
                        break;
                    case 2:
                        AddMotorcycle();
                        ui.Print("Motorcycle is successfully parked");
                        break;
                    case 3:
                        AddCar();
                        ui.Print("Car is successfully parked");
                        break;
                    case 4:
                        AddBus();
                        ui.Print("Bus is successfully parked");
                        break;
                    case 5:
                        AddBoat();
                        ui.Print("Boat is successfully parked");
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        ui.Print("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }

            } while (!success);
        }

        public Vehicle AddVehicle()
        {
            ui.Print("Registration number: ");
            regNo = ui.GetInput();
            VRegistrationNumber(regNo);
            ui.Print("Color: ");
            color = ui.GetInput();
            ui.Print("Number of wheels: ");
            numOfWheels = int.Parse(ui.GetInput());
            return new Vehicle(regNo, color, numOfWheels);
        }

        private bool VRegistrationNumber(string regNo)
        {
            var vList = garageHandler.garage.Vehicles;

            for (int i = 0; i < vList.Length; i++)
            {
                if (vList[i] != null)
                {

                    if (regNo.Length < 4 || regNo.Length > 4 || vList[i].RegNo.ToLower() == regNo.ToLower())
                    {
                        ui.Print("atleast 4 characters unique registration number is allowed!");
                        AddVehicleMenu();
                        return false;
                    }
                }
            }
            return true;
        }

        private void AddAirPlane()
        {
            var vehicle = AddVehicle();
            numOfEngines = ui.AskForInt("Number of engines of the airplane:");
            var airplane = new Airplane(vehicle.RegNo, vehicle.Color, vehicle.NumOfWheels, numOfEngines);
            garageHandler.garage.Add(airplane);

        }


        private void AddMotorcycle()
        {
            var vehicle = AddVehicle();
            cylinderVolume = ui.AskForInt("Number of cylinder of motorcycle: ");
            var motorcycle = new Motorcycle(vehicle.RegNo, vehicle.Color, vehicle.NumOfWheels, cylinderVolume);
            garageHandler.garage.Add(motorcycle);

        }

        private void AddCar()
        {
            var vehicle = AddVehicle();
            fuelType = ui.AskForString("Car's fuelType: ");
            var car = new Car(vehicle.RegNo, vehicle.Color, vehicle.NumOfWheels, fuelType);
            garageHandler.garage.Add(car);
            
        }

        private void AddBus()
        {
            var vehicle = AddVehicle();
            numberOfSeats = ui.AskForInt("Number of seats of the bus: ");
            var bus = new Bus(vehicle.RegNo, vehicle.Color, vehicle.NumOfWheels, numberOfSeats);
        }

        private void AddBoat()
        {
            var vehicle = AddVehicle();
            lengthOfBoat = ui.AskForInt("Length of the boat: ");
            var boat = new Boat(vehicle.RegNo, vehicle.Color, vehicle.NumOfWheels, lengthOfBoat);
        }
    }
}