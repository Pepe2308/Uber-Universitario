using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber_Universitario.Models;
using Uber_Universitario.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Uber_Universitario
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        
		public LoginPage ()
		{
			InitializeComponent ();
            enterButton.Clicked += enterButton_Clicked;
            //createDataForDataBase(); //activar cuando se instala por primera vez la aplicación

        }

        private async void enterButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(userEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una matricula", "Aceptar");
                userEntry.Focus();
                return;
            }
            else if(string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una contraseña", "Aceptar");
                passwordEntry.Focus();
                return;
            }
            else
            {
                waitActivityIndicator.IsRunning = true;
                var user = new Users();

                using (var datos = new DataAccess())
                {
                    user = datos.GetUser(userEntry.Text, passwordEntry.Text);
                }
                if(user ==  null)
                {
                    await DisplayAlert("ERROR", "USUARIO O CONTRASEÑA INCORRECTOS", "Aceptar");
                    userEntry.Text = null;
                    passwordEntry.Text = null;
                    return;
                }
                else
                {
                    enterButton.IsEnabled = false;
                    forgetPasswordButton.IsEnabled = false;
                    createAccountButton.IsEnabled = false;
                    waitActivityIndicator.IsRunning = true;
                    await Task.Delay(3000);
                    waitActivityIndicator.IsRunning = false;
                    await Navigation.PushAsync(new MainPage(user));
                }

                waitActivityIndicator.IsRunning = false;
            }
        }

        private async void createAccountButton_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new CreateAccountPage());
        }


        private async void forgetPasswordButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgetPasswordPage());
        }

        private void createDataForDataBase()
        {

            double enrollmentId = 1217000;
            for(int i = 0; i < 1000; i++)
            {
                var uabcUser = new UABC
                {
                    EnrollmentID = enrollmentId++.ToString()
                };
                using (var data = new DataAccess())
                {
                    data.InsertEnrollmentID(uabcUser);
                }

            }

        }
    }
}