using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uber_Universitario.Models
{
    public class UABC
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string EnrollmentID { get; set; }
    }
}
