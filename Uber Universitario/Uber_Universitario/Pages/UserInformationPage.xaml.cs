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
	public partial class UserInformationPage : ContentPage
	{
		public UserInformationPage (Users user)
		{
			InitializeComponent ();
            BindingContext = user;
            passwordLabel.FormattedText = "*****";
		}
	}
}