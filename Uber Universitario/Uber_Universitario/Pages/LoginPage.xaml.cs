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
                    await DisplayAlert("ERROR", "USUARIO INCORRECTO", "Aceptar");
                }
                else
                {
                    Application.Current.MainPage = new MainPage(user);

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

        }
    }
}