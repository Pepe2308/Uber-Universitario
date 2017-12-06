using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uber_Universitario.Models
{
    public class Trip
    {
        [AutoIncrement,PrimaryKey]
        public int ID { get; set; }
        public int ArrivalTime { get; set; }
        public float TripFee { get; set; }
        public bool TripStatus { get; set; }
        public int DriverID { get; set; }
        public int PassengerID { get; set; }
    }
}
