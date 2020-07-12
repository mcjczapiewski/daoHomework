using System;

namespace daoHomework
{
    internal class Program
    {
        private static void Main()
        {
            IVehicleDao vehicleDao = new VehicleDaoImpl();

            ProgramLogic.PrintAllVehicles(vehicleDao);

            ProgramLogic.UpdateValue(vehicleDao);

            ProgramLogic.GetSpecificRecord(vehicleDao);

            ProgramLogic.DeleteRecord(vehicleDao);
        }
    }
}