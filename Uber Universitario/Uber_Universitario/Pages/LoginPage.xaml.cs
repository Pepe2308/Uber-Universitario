using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                await DisplayAlert("Bien", "Ingresaste sesión", "Aceptar");
                waitActivityIndicator.IsRunning = false;
            }
        }
    }
}