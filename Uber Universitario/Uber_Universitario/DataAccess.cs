using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;
using Uber_Universitario.Models;
using System.Linq;


namespace Uber_Universitario
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma,
                Path.Combine(config.DirectorioDB, "UberUniversitario.db3"));
            connection.CreateTable<Users>();
            connection.CreateTable<Car>();
            connection.CreateTable<Driver>();
            connection.CreateTable<UABC>();
            connection.CreateTable<Passenger>();
        }
        #region Users methods
        public void InsertUser(Users user)
        {
            connection.Insert(user);
        }

        public void UpdateUser(Users user)
        {
            connection.Update(user);
        }

        public void DeleteUser(Users user)
        {
            connection.Delete(user);
        }

        public Users GetUser(int ID)
        {
            return connection.Table<Users>().FirstOrDefault(c => c.ID == ID);
        }
        
        public List<Users> GetUsers()
        {
            return connection.Table<Users>().OrderBy(c => c.LastName).ToList() ;
        }
        #endregion

        #region Car Methods
        public void InsertCar(Car car)
        {
            connection.Insert(car);
        }

        public void DeleteCar(Car car)
        {
            connection.Delete(car);
        }

        public Car GetCar(int ID)
        {
            return connection.Table<Car>().FirstOrDefault(c => c.ID == ID);
        }

        public List<Car> GetCars()
        {
            return connection.Table<Car>().OrderBy(c => c.Model).ToList();
        }
#endregion



        public void Dispose()
        {
            connection.Dispose();
        }

    }
}
