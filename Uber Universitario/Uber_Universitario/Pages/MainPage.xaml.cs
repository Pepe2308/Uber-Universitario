
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Uber_Universitario.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Uber_Universitario.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        private Users user;
        public Car car;
        

        public MainPage (Users user)
		{
			InitializeComponent ();
            BindingContext = user;
            this.user = user;
            string fullName = user.Name.ToString() + " " + user.LastName.ToString();
            userNameLabel.Text = fullName;
            Locator();

            using (var datos = new DataAccess())
            {
                car = datos.GetCarsByDriverId(user.ID).FirstOrDefault();
            }
            if(car != null)
            {
                reservedSeatsLabel.Text = "Asientos reservados: " + car.ReservedSeats.ToString();
                availableSeatsLabel.Text = "Asientos disponibles: " + (car.Seats - car.ReservedSeats).ToString();
            }

            if(user.tripActivated)
            {
                reservedSeatsLabel.IsVisible = false;
                availableSeatsLabel.IsVisible = false;
                cancelTrip.IsVisible = true;
                tripProgressLabel.IsVisible = true;
                tiempoRestante.IsVisible = true;
                tiempoRestante.Text = "Tiempo restante de llegada a uabc: 20 min";
                MyMap.Pins.Clear();
            }



            if (user.driverRegister == true)
                registerDriverButton.IsVisible = false;
            else
            {
                accountTypeButton.Text = "P";
                accountTypeButton.IsEnabled = false;
               // accountTypeSwitch.IsEnabled = false;
            }

            if (user.AccountType.Equals("conductor".ToUpper()))
            {
                //accountTypeSwitch.IsToggled = true;
                accountTypeButton.Text = "C";
                availableSeatsLabel.IsVisible = true;
                reservedSeatsLabel.IsVisible = true;
                carsInfoButton.IsVisible = true;

            }

            //if (!accountTypeSwitch.IsToggled)
            //{
            //    accountTypeButton.Text = "P";
            //    availableSeatsLabel.IsVisible = false;
            //    reservedSeatsLabel.IsVisible = false;
            //    carsInfoButton.IsVisible = false;
            //}

            if (user.AccountType.Equals("pasajero".ToUpper()))
            {
                accountTypeButton.Text = "P";
                availableSeatsLabel.IsVisible = false;
                reservedSeatsLabel.IsVisible = false;
                carsInfoButton.IsVisible = false;
            }



            

		}



        private async void RegisterDriverButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarRegistrationPage(user)); 
        }

        private  void accountTypeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            
            if(!e.Value)
            {
                user.AccountType = "pasajero".ToUpper();
                using (var datos = new DataAccess())
                {
                    datos.UpdateUser(user);
                }
                refreshPage();
            }
            else if(e.Value)
            {
                user.AccountType = "conductor".ToUpper();
                using (var datos = new DataAccess())
                {
                    datos.UpdateUser(user);
                }
                refreshPage();
            }
            //refreshPage();

        }

        public void refreshPage()
        {
                    var vUpdatedPage = new MainPage(user);
                    Navigation.InsertPageBefore(vUpdatedPage, this);
                    Navigation.PopAsync();
        }

        private async void imageAccountButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserInformationPage(user));
        }

        private async void Locator()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var location = await locator.GetPositionAsync(timeout: TimeSpan.FromMilliseconds(10000));
            var position = new Xamarin.Forms.Maps.Position(location.Latitude, location.Longitude);
            
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.3)));
            var pin1 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.479336, -116.820351),
                Label = "Orlando Dante López Moreno",
                Address = "Delegacion La Presa"
            };
            var pin2 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.508846, -116.868948),
                Label = "Carlos Gonzalez",
                Address = "Villafontana"
            };
            var pin3 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.528023, -117.019554),
                Label = "Fernanda Castro Ramirez",
                Address = "Prol Paseo de los Heroes 96-98"
            };
            var pin4 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.534838, -116.950699),
                Label = "Karen Nayely Perez Ramos",
                Address = "Calz del Tecnológico 2100"
            };
            var pin5 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.532094, -117.035273),
                Label = "Yair Eduardo Castrejon",
                Address = "Zona Centro"
            };
            var pin6 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.497361, -116.966468),
                Label = "Kimberly Ramos Garcia",
                Address = "Blvd. Gustavo Diaz Ordaz"
            };
            var pin7 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.51445, -116.9926),
                Label = "Rene Alain Vázquez Dominguez",
                Address = "20 de Noviembre"
            };
            var pin8 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.518889, -117.124167),
                Label = "Cesar Solano Ferreiro",
                Address = "Playas De Tijuana"
            };
            var pin9 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.436991, -117.030123),
                Label = "Jose Manuel Alvarez Cervantes",
                Address = "Santa Fe 3ra. Seccion"
            };
            var pin10 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.510256, -116.922687),
                Label = "Omar Contreras Garcia",
                Address = "Pórticos del Lago"
            };
            var pin11 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.52973, -116.946239),
                Label = "Zulema Alarcón Jimenez",
                Address = "Otay Constituyentes"
            };
            var pin12 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.448809, -116.909039),
                Label = "Maria del Refugio Cervantes",
                Address = "Pinos de La Presa"
            };
            var pin13 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.465532, -116.874838),
                Label = "Ariana Alvarez Zamorano",
                Address = "El Florido"
            };
            var pin14 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.471632, -116.913314),
                Label = "Nahia Vázquez Dominguez",
                Address = "Villa del Sol"
            };
            var pin15 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.499257, -116.858572),
                Label = "Leia Vázquez Dominguez",
                Address = "El nido"
            };
            var pin16 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.377869, -116.936671),
                Label = "Vannesa Soles",
                Address = "Natura"
            };
            var pin17 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.496943, -116.932732),
                Label = "Marco Hernandez",
                Address = "Macroplaza"
            };
            var pin18 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(32.463219, -116.827715),
                Label = "Luis Echeverria",
                Address = "El Refugio"
            };


            pin1.Clicked += Pin_Clicked;
            pin2.Clicked += Pin_Clicked;
            pin3.Clicked += Pin_Clicked;
            pin4.Clicked += Pin_Clicked;
            pin5.Clicked += Pin_Clicked;
            pin6.Clicked += Pin_Clicked;
            pin7.Clicked += Pin_Clicked;
            pin8.Clicked += Pin_Clicked;
            pin9.Clicked += Pin_Clicked;
            pin10.Clicked += Pin_Clicked;
            pin11.Clicked += Pin_Clicked;
            pin12.Clicked += Pin_Clicked;
            pin13.Clicked += Pin_Clicked;
            pin14.Clicked += Pin_Clicked;
            pin15.Clicked += Pin_Clicked;
            pin16.Clicked += Pin_Clicked;
            pin17.Clicked += Pin_Clicked;
            pin18.Clicked += Pin_Clicked;


            if (user.AccountType.Equals("pasajero".ToUpper()))
            {
                MyMap.Pins.Add(pin1);
                MyMap.Pins.Add(pin2);
                MyMap.Pins.Add(pin3);
                MyMap.Pins.Add(pin4);
                MyMap.Pins.Add(pin5);
                MyMap.Pins.Add(pin6);
                MyMap.Pins.Add(pin7);
                MyMap.Pins.Add(pin8);
                MyMap.Pins.Add(pin9);
                MyMap.Pins.Add(pin10);
                MyMap.Pins.Add(pin11);
                MyMap.Pins.Add(pin12);
                MyMap.Pins.Add(pin13);
                MyMap.Pins.Add(pin14);
                MyMap.Pins.Add(pin15);
                MyMap.Pins.Add(pin16);
                MyMap.Pins.Add(pin17);
                MyMap.Pins.Add(pin18);
            }

            if(location.Latitude == 32.533419 && location.Longitude == -116.964755)
            {
                 await DisplayAlert("Alerta del sistema", "El viaje concluyó", "Calificar conductor");
                 await Navigation.PushAsync(new CalificarConductorPage(user));
            }


        }

        private async void Pin_Clicked(object sender, EventArgs e)
        {

            var selectedPin = sender as Pin;
            //await DisplayAlert(selectedPin?.Label, selectedPin?.Address, "OK");
            Driver driver = new Driver();
            using (var datos = new DataAccess())
            {
                driver = datos.GetDriverByName(selectedPin?.Label.ToString());
            }

            
            await Navigation.PushAsync(new TripSelectionPage(driver,user));
        }

        private async void carsInfoButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterCarPage(user,-1));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
             //Application.Current.MainPage = new NavigationPage(new MainPage(user));
        }

        private async void cancelTrip_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Cancelación", "¿Está seguro que desea cancelar el viaje?", "Aceptar", "Cancelar");
            if(response)
            {
                user.tripActivated = false;
                
                using (var datos = new DataAccess())
                {
                    datos.UpdateUser(user);
                }
                await DisplayAlert("Notificación", "Tu viaje ha sido cancelado", "Aceptar");
                return;
            }
        }

        private void accountTypeButton_Clicked(object sender, EventArgs e)
        {
            if (user.AccountType.Equals("conductor".ToUpper()))
            {
                user.AccountType = "pasajero".ToUpper();
                using (var datos = new DataAccess())
                {
                    datos.UpdateUser(user);
                }
                refreshPage();
            }
            else if (user.AccountType.Equals("pasajero".ToUpper()))
            {
                user.AccountType = "conductor".ToUpper();
                using (var datos = new DataAccess())
                {
                    datos.UpdateUser(user);
                }
                refreshPage();
            }
        }
    }
}