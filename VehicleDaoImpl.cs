using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

namespace daoHomework
{
    public class VehicleDaoImpl : IVehicleDao
    {
        public List<Vehicle> vehicles;

        public VehicleDaoImpl()
        {
            vehicles = new List<Vehicle>();
            using var streamReader = new StreamReader("vehiclesList.csv");
            var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            reader.Configuration.RegisterClassMap<UserMap>();
            vehicles = reader.GetRecords<Vehicle>().ToList();

        }

        public List<Vehicle> GetAllVehicles()
        {
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
                matchedVehicle.MaxPassengersNumber = vehicle.MaxPassengersNumber;
                Console.WriteLine($"Vehicle with ID {matchedVehicle.VehicleType} has been updated in database.");
            }
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
            Console.WriteLine($"Vehicle with ID {vehicle.VehicleID} has been removed from database.");
        }
    }
}