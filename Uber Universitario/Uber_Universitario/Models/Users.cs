using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace Uber_Universitario.Models
{
    public class Users
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EnrollmentID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string AccountType { get; set; }
        public string Localitation { get; set; }
        public string Password { get; set; }
        public bool driverRegister { get; set; }
        public bool tripActivated { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} ", Name, LastName);
        }
    }
}
