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
	public partial class ChangePasswordPage : ContentPage
	{
        public Users user;
		public ChangePasswordPage (Users user)
		{
			InitializeComponent ();
            this.user = user;
		}

        private async void nextPageButton_Clicked(object sender, EventArgs e)
        {
            if(user.Password == actualPassword.Text)
            {
                await Navigation.PushAsync(new NextPasswordChangePage(user));
            }
            else
            {
                await DisplayAlert("Error de validación", "La contraseña ingresada es incorrecta", "Aceptar");
                return;
            }

        }
    }
}