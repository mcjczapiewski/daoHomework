using System;

namespace daoHomework
{
    internal class ProgramLogic
    {
        internal static void DeleteRecord(IVehicleDao vehicleDao)
        {
            GetUserInput("What is the Vehicle ID to delete?",
                         out int userPassedValue);
            var vehicleToDelete = vehicleDao.GetVehicle(userPassedValue);
            vehicleDao.DeleteVehicle(vehicleToDelete);
        }

        internal static void GetSpecificRecord(IVehicleDao vehicleDao)
        {
            GetUserInput("What is the Vehicle ID you want to retrieve information?",
                         out int userPassedValue);
            var vehicleRetrieved = vehicleDao.GetVehicle(userPassedValue);
            Console.WriteLine($"Vehicle ID: {vehicleRetrieved.VehicleID}, " +
                $"Type: {vehicleRetrieved.VehicleType}, " +
                $"Wheels: {vehicleRetrieved.WheelsNumber}, " +
                $"Passengers capacity: {vehicleRetrieved.MaxPassengersNumber}");
        }

        internal static void PrintAllVehicles(IVehicleDao vehicleDao)
        {
            foreach (var vehicle in vehicleDao.GetAllVehicles())
            {
                Console.WriteLine($"Vehicle ID: {vehicle.VehicleID}, " +
                    $"Type: {vehicle.VehicleType}, " +
                    $"Wheels: {vehicle.WheelsNumber}, " +
                    $"Passengers capacity: {vehicle.MaxPassengersNumber}");
            }
        }

        internal static void UpdateValue(IVehicleDao vehicleDao)
        {
            GetUserInput("What is the Vehicle ID to update?",
                         out int userPassedValue);
            var vehicleToUpdate = new Vehicle(userPassedValue);

            GetUserInput("What should be new available seats value?",
                         out userPassedValue);
            vehicleToUpdate.MaxPassengersNumber = userPassedValue;

            vehicleDao.UpdateMaxPassengersNumber(vehicleToUpdate);
        }

        private static void GetUserInput(string message, out int userPassedValue)
        {
            Console.WriteLine(message);
            Console.Write("> ");
            var passedValue = Console.ReadLine();
            userPassedValue = Convert.ToInt32(passedValue);
        }
    }
}