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
	public partial class NewPassengerPage : ContentPage
	{
		public NewPassengerPage ()
		{
			InitializeComponent ();
		}

        private void AceptarButton_Clicked(object sender, EventArgs e)
        {

        }

        private void cancelarButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}