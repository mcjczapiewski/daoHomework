namespace daoHomework
{
    public class Vehicle
    {
        public Vehicle(int vehicleID, string vehicleType = "unkown", int wheelsNumber = 4, int maxPassengersNumber = 2)
        {
            VehicleID = vehicleID;
            VehicleType = vehicleType;
            WheelsNumber = wheelsNumber;
            MaxPassengersNumber = maxPassengersNumber;
        }

        public int MaxPassengersNumber { get; set; }
        public int VehicleID { get; set; }
        public string VehicleType { get; set; }
        public int WheelsNumber { get; set; }
    }
}