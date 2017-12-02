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
	public partial class UpdatePhoneNumberPage : ContentPage
	{
        Users user;
		public UpdatePhoneNumberPage (Users user)
		{
			InitializeComponent ();
            BindingContext = user;
            this.user = user;
		}

        private async void UpdatePhoneNumberButton_Clicked(object sender, EventArgs e)
        {
            user.PhoneNumber = phoneEntry.Text;
            using (var datos = new DataAccess())
            {
                datos.UpdateUser(user);
            }
            await DisplayAlert("Exito!", "Haz actualizado el numero celular", "Ok");
            await Navigation.PopAsync();

        }
    }
}