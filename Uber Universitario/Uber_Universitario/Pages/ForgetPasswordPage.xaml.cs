using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Uber_Universitario.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgetPasswordPage : ContentPage
	{
		public ForgetPasswordPage ()
		{
			InitializeComponent ();
		}

        private async void passwordRecoveryButton_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(enrollmentIdEntry.Text))
            {
                await DisplayAlert("Éxito!", "Tu contraseña ha sido enviada al correo registrado", "Aceptar");
                return;
            }
            else
            {
                await DisplayAlert("Error", "Debe ingresar una matricula", "Aceptar");
            }
        }
        public async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}