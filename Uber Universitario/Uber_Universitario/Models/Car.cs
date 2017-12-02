using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace Uber_Universitario.Models
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public string LicensePlate { get; set; }
        public int Seats { get; set; }
        public float TravelFee { get; set; }
        public int DriverID { get; set; }
        public int ReservedSeats { get; set; }

    }
}
