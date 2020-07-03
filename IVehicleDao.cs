using System.Collections.Generic;

namespace daoHomework
{
    public interface IVehicleDao
    {
        public List<Vehicle> GetAllVehicles();
        public Vehicle GetVehicle(int vehicleID);
        public void UpdateVehicle(Vehicle vehicle);
        public void DeleteVehicle(Vehicle vehicle);
    }
}