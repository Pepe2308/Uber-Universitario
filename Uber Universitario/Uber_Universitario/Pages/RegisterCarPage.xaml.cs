﻿using System;
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
	public partial class RegisterCarPage : ContentPage
	{
        Users user;
        List<Car> carList = new List<Car>();
        Car car;
        int carNum;
        public RegisterCarPage (Users user, int carNum)
		{
			InitializeComponent ();
            BindingContext = user;
            this.user = user;
            this.carNum = carNum;

            using (var datos = new DataAccess())
            {
                carList = datos.GetCarsByDriverId(user.ID);
            }

                driverNameLabel.Text = "Nombre: " + user.Name.ToString() + " " + user.LastName.ToString();
                registerCarsLabel.Text = "Total de automóviles registrados: " + carList.Count();

            registerCarsPicker.Title = "Automóvil";
            for (int i = 1; i <= carList.Count(); i++)
            {
                registerCarsPicker.Items.Add(i.ToString());
            }

            registerCarsPicker.SelectedIndex = 0;


            if (carList.Count == 0)
            {
                carDataLabel.Text = "No se tienen automóviles registrados";
                removeCar.IsEnabled = false;
            }
            if (registerCarsPicker.SelectedIndex == -1)
            {
                carDataLabel.Text = "Datos del automóvil ";
                carTypeLabel.Text = "Tipo: ";
                carMakeLabel.Text = "Marca: ";
                carColorLabel.Text = "Color: ";
                licensePlateLabel.Text = "Matrícula: ";
                yearLabel.Text = "Año: ";
            }
            else
            {
                carDataLabel.Text = "Datos del automóvil " + (registerCarsPicker.SelectedIndex+1).ToString();
                carTypeLabel.Text = "Tipo: " + carList.ElementAt(registerCarsPicker.SelectedIndex).Type; 
                carMakeLabel.Text = "Marca: " + carList.ElementAt(registerCarsPicker.SelectedIndex).Brand;
                carColorLabel.Text = "Color: " + carList.ElementAt(registerCarsPicker.SelectedIndex).Color;
                licensePlateLabel.Text = "Matrícula: " + carList.ElementAt(registerCarsPicker.SelectedIndex).LicensePlate.ToUpper();
                yearLabel.Text = "Año: " + carList.ElementAt(registerCarsPicker.SelectedIndex).ModelYear.ToString();
            }
           

            
		}

        private async void addCar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarRegistrationPage(user));
        }

        private async void removeCar_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayAlert("Eliminación de vehiculos", "¿Está seguro de que desea eliminar la información del automóvil seleccionado?", "Aceptar", "Cancelar");
            if(res)
            {
                car = carList.ElementAt<Car>(registerCarsPicker.SelectedIndex);
                using (var datos = new DataAccess())
                {
                    datos.DeleteCar(car);
                }
                refreshPage();
            }

        }

        public void refreshPage()
        {
            var vUpdatedPage = new RegisterCarPage(user,registerCarsPicker.SelectedIndex);
            Navigation.InsertPageBefore(vUpdatedPage, this);
            Navigation.PopAsync();
        }

        private void registerCarsPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //registerCarsPicker.SelectedIndex = carNum;
            //refreshPage();
        }
    }
}