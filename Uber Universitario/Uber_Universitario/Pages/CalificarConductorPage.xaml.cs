using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber_Universitario.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Uber_Universitario.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalificarConductorPage : ContentPage
	{
        Users user;
        public CalificarConductorPage(Users user)
		{
			InitializeComponent ();
            BindingContext = user;
            this.user = user;

            driverNameLabel.Text = "Conductor: " + user.Name + " " + user.LastName;

		}

        private async void calificar_Clicked(object sender, EventArgs e)
        {
            Driver driver;
            string driverName = user.Name + " " + user.LastName;
            using (var datos = new DataAccess())
            {
                driver = datos.GetDriverByName(driverName);
                driver.Calification = 4;
                datos.UpdateDriver(driver);
                await DisplayAlert("Gracias!", "Gracias por calificar al conductor", "Aceptar");
                await Navigation.PopAsync();
            }
            
        }
    }
}