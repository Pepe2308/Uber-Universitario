using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace Uber_Universitario.Models
{
    public class Driver : Users
    {
        public string UsualRoute { get; set; }
        public float Calification { get; set; }
        
        public int CarID { get; set; }
       // public List<Car> Cars { get; set; }
    }
}
