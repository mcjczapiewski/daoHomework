namespace daoHomework
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VehicleType { get; set; }
        public int WheelsNumber { get; set; }
        public int MaxPassengersNumber { get; set; }

        public Vehicle(int vehicleID, int maxPassengersNumber=2, string vehicleType="unkown", int wheelsNumber=4)
        {
            VehicleID = vehicleID;
            VehicleType = vehicleType;
            WheelsNumber = wheelsNumber;
            MaxPassengersNumber = maxPassengersNumber;
        }
    }
}