using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uber_Universitario.Models;
using Uber_Universitario.Pages;
using Xamarin.Forms;

namespace Uber_Universitario
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            var user = new Users()
            {
                Name = "JOSE MANUEL"
            };

            //MainPage = new NavigationPage(new MainPage(user));
            Application.Current.Properties["switch"] = "0";
            Application.Current.Properties["carNumber"] = "-1";
            Application.Current.SavePropertiesAsync();
            MainPage = new NavigationPage(new LoginPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
