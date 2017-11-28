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
	public partial class MainPage : ContentPage
	{
        private Users user;
        

        public MainPage (Users user)
		{
			InitializeComponent ();
            BindingContext = user;
            this.user = user;

            if(user.driverRegister == true)        
                registerDriverButton.IsVisible = false;

            if (user.AccountType.Equals("conductor".ToUpper()))
            {
                accountTypeSwitch.IsToggled = true;
                availableSeatsLabel.IsVisible = true;
                reservedSeatsLabel.IsVisible = true;
                carsInfoButton.IsVisible = true;

            }

            if (!accountTypeSwitch.IsToggled)
            {
                availableSeatsLabel.IsVisible = false;
                reservedSeatsLabel.IsVisible = false;
                carsInfoButton.IsVisible = false;
            }

		}

        private async void RegisterDriverButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarRegistrationPage(user)); 
        }

        private  void accountTypeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if(!accountTypeSwitch.IsToggled)
            {
                user.AccountType = "pasajero".ToUpper();
                using (var datos = new DataAccess())
                {
                    datos.UpdateUser(user);
                }
            }
            else if(accountTypeSwitch.IsToggled)
            {
                user.AccountType = "conductor".ToUpper();
                using (var datos = new DataAccess())
                {
                    datos.UpdateUser(user);
                }
            }
        }

        private async void imageAccountButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserInformationPage(user));
        }
    }
}