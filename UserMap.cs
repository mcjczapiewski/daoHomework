using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;

namespace daoHomework
{
    sealed class UserMap : ClassMap<Vehicle>
    {
        public UserMap()
        {
            Map(m => m.VehicleID).Name("ID");
            Map(m => m.VehicleType).Name("Type");
            Map(m => m.WheelsNumber).Name("Wheels");
            Map(m => m.MaxPassengersNumber).Name("Seats");
        }
    }
}
