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
		public MainPage (Users user)
		{
			InitializeComponent ();
            BindingContext = user;

		}

        private async void RegisterDriverButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarRegistrationPage()); 
        }
    }
}