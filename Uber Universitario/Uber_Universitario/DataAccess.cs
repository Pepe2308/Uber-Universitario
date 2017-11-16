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
        }

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

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
