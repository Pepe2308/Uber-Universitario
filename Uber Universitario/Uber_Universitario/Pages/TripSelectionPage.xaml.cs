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
	public partial class TripSelectionPage : ContentPage
	{
        Driver driver;
        Car car;
        Users user;
		public TripSelectionPage (Driver driver,Users user)
		{
			InitializeComponent ();
            BindingContext = driver;
            this.driver = driver;
            this.user = user;

            using (var datos = new DataAccess())
            {
                car = datos.GetCarsByDriverId(driver.ID).FirstOrDefault();
            }

                driverNameLabel.Text = "Conductor: " + driver.Name + " " + driver.LastName;
                travelFeeLabel.Text = "$" + car.TravelFee.ToString();
		}

        private async void seatReserve_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeatsReservationPage(car,user));
        }

        private void cancel_Clicked(object sender, EventArgs e)
        {

        }
    }
}