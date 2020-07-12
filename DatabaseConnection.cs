using System;
using System.Data.SqlClient;

namespace daoHomework
{
    internal class DatabaseConnection
    {
        static IVehicleDao vehicleDao = new VehicleDaoImpl();

        public static SqlConnection dbConnection = new SqlConnection(@"Server=HORIZON17\SQLEXPRESS;Database=vehicleList;Trusted_Connection=True;");

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
    }
}