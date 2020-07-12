using System.Collections.Generic;

namespace daoHomework
{
    public interface IVehicleDao
    {
        public void AddVehicle(Vehicle vehicle);

        public void DeleteVehicle(Vehicle vehicle);

        public List<Vehicle> GetAllVehicles();

        public Vehicle GetVehicle(int vehicleID);

        public void UpdateMaxPassengersNumber(Vehicle vehicle);
    }
}