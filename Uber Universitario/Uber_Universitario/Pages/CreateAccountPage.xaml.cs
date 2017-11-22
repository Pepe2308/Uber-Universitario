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
	public partial class CreateAccountPage : ContentPage
	{
		public CreateAccountPage ()
		{
			InitializeComponent ();
		}

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nameEntry.Text))
            {
                await DisplayAlert("ERROR", "DEBE INGRESAR UN NOMBRE", "ACEPTAR");
                nameEntry.Focus();
                return;
            }
            else if(string.IsNullOrEmpty(lastNameEntry.Text))
            {
                await DisplayAlert("ERROR", "DEBE INGRESAR UN APELLIDO", "ACEPTAR");
                lastNameEntry.Focus();
                return;
            }
            else if(string.IsNullOrEmpty(cityEntry.Text))
            {
                await DisplayAlert("ERROR", "DEBE INGRESAR UNA CIUDAD", "ACEPTAR");
                cityEntry.Focus();
                return;
            }
            else if(string.IsNullOrEmpty(emailEntry.Text))
            {
                await DisplayAlert("ERROR", "DEBE INGRESAR UN CORREO ELECTRÓNICO", "ACEPTAR");
                emailEntry.Focus();
                return;
            }
            else if(string.IsNullOrEmpty(enrollmentIDEntry.Text))
            {
                await DisplayAlert("ERROR", "DEBE INGRESAR UNA MATRICULA", "ACEPTAR");
                enrollmentIDEntry.Focus();
                return;
            }
            else if(string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("ERROR", "DEBE INGRESAR UNA CONTRASEÑA", "ACEPTAR");
                passwordEntry.Focus();
                return;
            }
            else if(string.IsNullOrEmpty(phoneNumberEntry.Text))
            {
                await DisplayAlert("ERROR", "DEBE INGRESAR UN TELEFONO", "ACEPTAR");
                phoneNumberEntry.Focus();
                return;
            }
            else if(!emailEntry.Text.ToUpper().Contains("@UABC.EDU.MX"))
            {
                await DisplayAlert("ERROR", "DEBE INGRESAR UN CORREO ASOCIADO A UABC", "ACEPTAR");
                emailEntry.Focus();
                return;
            }
            else
            {
                var user = new Users
                {
                    Name = nameEntry.Text,
                    LastName = lastNameEntry.Text,
                    AccountType = "pasajero".ToUpper(),
                    City = cityEntry.Text,
                    Email = emailEntry.Text,
                    EnrollmentID = enrollmentIDEntry.Text,
                    Password = passwordEntry.Text,
                    PhoneNumber = phoneNumberEntry.Text
                };

                using (var datos = new DataAccess())
                {
                    datos.InsertUser(user);
                }

                    nameEntry.Text = string.Empty;
                    lastNameEntry.Text = string.Empty;
                    cityEntry.Text = string.Empty;
                    emailEntry.Text = string.Empty;
                    enrollmentIDEntry.Text = string.Empty;
                    passwordEntry.Text = string.Empty;
                    phoneNumberEntry.Text = string.Empty;

                await DisplayAlert("Éxito!", "Bienvenido a la aplicación", "Aceptar");
                Application.Current.MainPage = new MainPage(user);
            }
            

        }
    }
}