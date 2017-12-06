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
	public partial class SeatsReservationPage : ContentPage
	{
        Car car;
        Trip trip;
        Users user;
		public SeatsReservationPage (Car car,Users user)
		{
			InitializeComponent ();
            this.car = car;
            this.user = user;
            seatsPicker.Title = "Asientos";
            for (int i = 1; i <= car.Seats; i++)
            {
                seatsPicker.Items.Add(i.ToString());
            }
		}

        private async void aceptTripButton_Clicked(object sender, EventArgs e)
        {
            if(seatsPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Alerta", "Selecciona asientos", "Aceptar");
                return;
            }
            if(seatsPicker.SelectedIndex + 1 > (car.Seats - car.ReservedSeats))
            {
                await DisplayAlert("Solicitud de asientos", "No hay suficientes asientos disponibles", "Aceptar");
                return;
            }
            car.ReservedSeats = seatsPicker.SelectedIndex + 1;
            using (var datos = new DataAccess())
            {
                datos.UpdateCar(car);
            }
            trip = new Trip
            {
                DriverID = car.DriverID,
                TripFee = car.TravelFee,
                TripStatus = true,
                ArrivalTime = 15,
                PassengerID = user.ID

            };
            user.tripActivated = true;
            using (var datos = new DataAccess())
            {
                    datos.InsertTrip(trip);
                 datos.UpdateUser(user);
            }
            await DisplayAlert("Solicitud de asientos", "Viaje solicitado", "Aceptar");
            Navigation.PopAsync();
            DisplayAlert("Información del viaje", "El tiempo estimado de llegada a tu localización es de 20 minutos", "Aceptar");
            await Navigation.PopAsync();
            

        }

    }
}