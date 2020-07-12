using System;
using System.Collections.Generic;
using System.Linq;

namespace daoHomework
{
    public class VehicleDaoImpl : IVehicleDao
    {
        public static List<Vehicle> Vehicles = new List<Vehicle>();

        public void DeleteVehicle(Vehicle vehicle)
        {
            DatabaseConnection.ImportVehiclesFromDatabase();
            DatabaseConnection.ExecuteCommand(@$"DELETE FROM [dbo].[vehiclesList]
WHERE [ID] = {vehicle.VehicleID}");
            Vehicles.Remove(vehicle);
            Console.WriteLine($"Vehicle with ID {vehicle.VehicleID} has been removed from database.");
        }

        public List<Vehicle> GetAllVehicles()
        {
            return Vehicles;
        }

        public Vehicle GetVehicle(int vehicleID)
        {
            return Vehicles.First(vehicle => vehicle.VehicleID == vehicleID);
        }

        public void UpdateMaxPassengersNumber(Vehicle vehicle)
        {
            DatabaseConnection.ImportVehiclesFromDatabase();
            var matchedVehicle = Vehicles.FirstOrDefault(vehicleFromList => vehicleFromList.VehicleID == vehicle.VehicleID);
            if (matchedVehicle != null)
            {
                DatabaseConnection.ExecuteCommand(@$"UPDATE [dbo].[vehiclesList]
SET [Seats] = {vehicle.MaxPassengersNumber}
WHERE [ID] = {vehicle.VehicleID}");
                matchedVehicle.MaxPassengersNumber = vehicle.MaxPassengersNumber;
                Console.WriteLine($"Vehicle with ID {matchedVehicle.VehicleType} has been updated in database.");
            }
        }
    }
}