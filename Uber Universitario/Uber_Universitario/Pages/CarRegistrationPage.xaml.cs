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
	public partial class CarRegistrationPage : ContentPage
	{
        Users user;
		public CarRegistrationPage (Users user)
		{
			InitializeComponent ();
            AddCarType();
            AddCarMake();
            AddYears();
            this.user = user;
        }

        private void AddYears()
        {
            int year = 2018;
            yearCarPicker.Title = "Año del automóvil";
            for(int i = 0; i<100; i++)
            {
                yearCarPicker.Items.Add((year - i).ToString());
            }

        }

        private void AddCarType()
        {
            carTypePicker.Title = "Tipo de automóvil";
            carTypePicker.Items.Add("Coupé");
            carTypePicker.Items.Add("Sedán");
            carTypePicker.Items.Add("Camioneta");
            carTypePicker.Items.Add("Pickup");
        }

        private void AddCarMake()
        {
            carMakePicker.Title = "Marca del automóvil";
            carMakePicker.Items.Add("Acura");
            carMakePicker.Items.Add("Audi");
            carMakePicker.Items.Add("BMW");
            carMakePicker.Items.Add("Buick");
            carMakePicker.Items.Add("Cadillac");
            carMakePicker.Items.Add("Chevrolet");
            carMakePicker.Items.Add("Dodge");
            carMakePicker.Items.Add("Fiat");
            carMakePicker.Items.Add("Ford");
            carMakePicker.Items.Add("GMC");
            carMakePicker.Items.Add("Honda");
            carMakePicker.Items.Add("Hyundai");
            carMakePicker.Items.Add("Jeep");
            carMakePicker.Items.Add("Kia");
            carMakePicker.Items.Add("Mazda");
            carMakePicker.Items.Add("Mitsubishi");
            carMakePicker.Items.Add("Nissan");
            carMakePicker.Items.Add("Renault");
            carMakePicker.Items.Add("Toyota");
            carMakePicker.Items.Add("VolksWagen");

        }

        private async void registerCarButton_Clicked(object sender, EventArgs e)
        {
            registerCarButton.IsEnabled = false;
            if(carTypePicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "No se ha seleccionado el tipo del automóvil", "Aceptar");
                carTypePicker.Focus();
                return;
            }
            if (carMakePicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "No se ha seleccionado la marca del automóvil", "Aceptar");
                carMakePicker.Focus();
                return;
            }
            if(string.IsNullOrEmpty(carModel.ToString()))
            {
                await DisplayAlert("Error", "No se ha ingresado el modelo del automóvil", "Aceptar");
                carModel.Focus();
                return;
            }
            if (string.IsNullOrEmpty(carColor.ToString()))
            {
                await DisplayAlert("Error", "No se ha ingresado el color del automóvil", "Aceptar");
                carColor.Focus();
                return;
            }
            if (yearCarPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "No se ha seleccionado el año del automóvil", "Aceptar");
                yearCarPicker.Focus();
                return;
            }
            if (string.IsNullOrEmpty(carColor.ToString()))
            {
                await DisplayAlert("Error", "No se ha ingresado el número de placa del automóvil", "Aceptar");
                licensePlateEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(seatsEntry.ToString()))
            {
                await DisplayAlert("Error", "No se ha ingresado la capacidad máxima de asientos del automóvil", "Aceptar");
                seatsEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(usualRouteEntry.ToString()))
            {
                await DisplayAlert("Error", "No se ha ingresado la ruta habitual", "Aceptar");
                usualRouteEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(travelFeeEntry.ToString()))
            {
                await DisplayAlert("Error", "No se ha ingresado la tarifa del viaje", "Aceptar");
                travelFeeEntry.Focus();
                return;
            }

            var car = new Car
            {
                Type = carTypePicker.SelectedItem.ToString(),
                Brand = carMakePicker.SelectedItem.ToString(),
                Model = carModel.Text,
                ModelYear = Int32.Parse(yearCarPicker.SelectedItem.ToString()),
                LicensePlate = licensePlateEntry.Text,
                Color = carColor.Text,
                TravelFee = float.Parse(travelFeeEntry.Text),
                Seats = Int32.Parse(seatsEntry.Text),
                DriverID = user.ID
            };


            int carId;
            List<Car> carList;
            carList = new List<Car>();
            carList.Add(car);
            using (var datos = new DataAccess())
            {
                datos.DeleteAllCars();
                datos.InsertCar(car);
                carId = datos.GetCar().ID;
            }

            var driver = new Driver
            {
                CarID = carId,
                UsualRoute = usualRouteEntry.Text,
                Calification = 0,
                AccountType = "conductor".ToUpper(),
                City = user.City,
                Email = user.Email,
                ID = user.ID,
                EnrollmentID = user.EnrollmentID,
                LastName = user.LastName,
                Name = user.Name,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                //Cars = carList
                
            };

            using (var datos = new DataAccess())
            {
                datos.InsertDriver(driver);
            }


            using (var datos = new DataAccess())
            {
                user.driverRegister = true;
                datos.UpdateUser(user);
            }

            await DisplayAlert("Notificación de sistema", "Automóvil registrado exitosamente", "Aceptar");
            await Navigation.PopAsync();

        }
    }
}