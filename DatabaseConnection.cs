using System;
using System.Data.SqlClient;

namespace daoHomework
{
    internal class DatabaseConnection
    {
        static IVehicleDao vehicleDao = new VehicleDaoImpl();

        private static SqlConnection dbConnection = new SqlConnection(@"Server=HORIZON17\SQLEXPRESS;Database=vehicleList;Trusted_Connection=True;");

        public static void ExecuteCommand(string command)
        {
            SqlCommand cmd = new SqlCommand(command, dbConnection);
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        public static void ImportVehiclesFromDatabase()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT [ID], [Type], [Wheels], [Seats] FROM [dbo].[vehiclesList]", dbConnection);
            dbConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vehicle vehicle = new Vehicle(Convert.ToInt32(reader["ID"]),
                                              reader["Type"].ToString(),
                                              Convert.ToInt32(reader["Wheels"]),
                                              Convert.ToInt32(reader["Seats"]));
                vehicleDao.AddVehicle(vehicle);
            }
            reader.Close();
            dbConnection.Close();
        }

        public static void RemoveFromDatabase(int vehicleID)
        {
            ExecuteCommand(@$"DELETE FROM [dbo].[vehiclesList]
WHERE [ID] = {vehicleID}");
        }

        public static void UpdatePassengersSeatsInDatabase(Vehicle vehicle)
        {
            DatabaseConnection.ExecuteCommand(@$"UPDATE [dbo].[vehiclesList]
SET [Seats] = {vehicle.MaxPassengersNumber}
WHERE [ID] = {vehicle.VehicleID}");
        }
    }
}