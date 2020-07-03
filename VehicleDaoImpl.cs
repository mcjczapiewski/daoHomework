using System;
using System.Collections.Generic;
using System.Linq;

namespace daoHomework
{
    public class VehicleDaoImpl : IVehicleDao
    {
        List<Vehicle> vehicles;

        public VehicleDaoImpl()
        {
            vehicles = new List<Vehicle>();
            //TODO: dodawanie z pliku csv

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
            var matchedVehicle = vehicles.FirstOrDefault(vehicle => vehicle.VehicleID == 1); //TODO: wprowadzanie id pojazdu do usuniecia przez uzytkownika
            if (matchedVehicle != null)
            {
                vehicle.MaxPassengersNumber = 4; //TODO: new value from user
                Console.WriteLine($"Vehicle with ID {vehicle.VehicleID} has been updated in database.");
            }
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
            Console.WriteLine($"Vehicle with ID {vehicle.VehicleID} has been removed from database.");
        }
    }
}