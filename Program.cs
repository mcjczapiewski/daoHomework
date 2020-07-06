using System;

namespace daoHomework
{
    internal class Program
    {
        private static void Main()
        {
            DatabaseConnection.ImportVehiclesFromDatabase();
            IVehicleDao vehicleDao = new VehicleDaoImpl();

            //print all
            foreach (var vehicle in vehicleDao.GetAllVehicles())
            {
                Console.WriteLine($"Vehicle ID: {vehicle.VehicleID}, " +
                    $"Type: {vehicle.VehicleType}, " +
                    $"Wheels: {vehicle.WheelsNumber}, " +
                    $"Passengers capacity: {vehicle.MaxPassengersNumber}");
            }

            //update
            Console.WriteLine("What is the Vehicle ID to update?");
            Console.Write("> ");
            var passedValue = Console.ReadLine();
            var userPassedID = Convert.ToInt32(passedValue);
            var vehicleToUpdate = new Vehicle(userPassedID);

            Console.WriteLine("What should be new available seats value?");
            Console.Write("> ");
            passedValue = Console.ReadLine();
            int availableSeats = Convert.ToInt32(passedValue);
            vehicleToUpdate.MaxPassengersNumber = availableSeats;

            vehicleDao.UpdateMaxPassengersNumber(vehicleToUpdate);

            //get Vehicle
            Console.WriteLine("What is the Vehicle ID you want to retrieve information?");
            Console.Write("> ");
            passedValue = Console.ReadLine();
            userPassedID = Convert.ToInt32(passedValue);
            var vehicleRetrieved = vehicleDao.GetVehicle(userPassedID);
            Console.WriteLine($"Vehicle ID: {vehicleRetrieved.VehicleID}, " +
                $"Type: {vehicleRetrieved.VehicleType}, " +
                $"Wheels: {vehicleRetrieved.WheelsNumber}, " +
                $"Passengers capacity: {vehicleRetrieved.MaxPassengersNumber}");

            //delete
            Console.WriteLine("What is the Vehicle ID to delete?");
            Console.Write("> ");
            passedValue = Console.ReadLine();
            userPassedID = Convert.ToInt32(passedValue);
            var vehicleToDelete = vehicleDao.GetVehicle(userPassedID);
            vehicleDao.DeleteVehicle(vehicleToDelete);
        }
    }
}