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
	public partial class NextPasswordChangePage : ContentPage
	{
        Users user;
		public NextPasswordChangePage (Users user)
		{
			InitializeComponent ();
            this.user = user;
		}

        private async void changePassword_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(newPasswordEntry.Text))
            {
                await DisplayAlert("Notificación", "Debe ingresar una contraseña", "Aceptar");
                newPasswordEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(newPasswordConfirmationEntry.Text))
            {
                await DisplayAlert("Notificación", "Debe ingresar una confirmación de la contraseña", "Aceptar");
                newPasswordConfirmationEntry.Focus();
                return;
            }
            if(newPasswordEntry.Text == newPasswordConfirmationEntry.Text)
            {
                user.Password = newPasswordEntry.Text;
                using(var datos = new DataAccess())
                {
                    datos.UpdateUser(user);
                }
                await DisplayAlert("Notificación", "Contraseña actualizada", "Aceptar");
                Navigation.PopAsync();
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Notificación", "Las contraseñas ingresadas no coinciden", "Aceptar");
                newPasswordEntry.Text = string.Empty;
                newPasswordConfirmationEntry.Text = string.Empty;
                return;
            }
        }
    }
}