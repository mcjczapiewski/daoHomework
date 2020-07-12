using System;
using System.Collections.Generic;
using System.Linq;

namespace daoHomework
{
    public class VehicleDaoImpl : IVehicleDao
    {
        private static List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            DatabaseConnection.RemoveFromDatabase(vehicle.VehicleID);
            vehicles.Remove(vehicle);
            Console.WriteLine($"Vehicle with ID {vehicle.VehicleID} has been removed from database.");
        }

        public List<Vehicle> GetAllVehicles()
        {
            DatabaseConnection.ImportVehiclesFromDatabase();
            return vehicles;
        }

        public Vehicle GetVehicle(int vehicleID)
        {
            return vehicles.First(vehicle => vehicle.VehicleID == vehicleID);
        }

        public void UpdateMaxPassengersNumber(Vehicle vehicle)
        {
            var matchedVehicle = vehicles.FirstOrDefault(vehicleFromList => vehicleFromList.VehicleID == vehicle.VehicleID);
            if (matchedVehicle != null)
            {
                DatabaseConnection.UpdatePassengersSeatsInDatabase(vehicle);
                matchedVehicle.MaxPassengersNumber = vehicle.MaxPassengersNumber;
                Console.WriteLine($"Vehicle with ID {matchedVehicle.VehicleType} has been updated in database.");
            }
        }
    }
}