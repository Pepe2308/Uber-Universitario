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
	public partial class CarRegistrationPage : ContentPage
	{
        
		public CarRegistrationPage ()
		{
			InitializeComponent ();
            AddCarType();
        }

        public void AddCarType()
        {
            carTypePicker.Items.Add("Acura");
            carTypePicker.Items.Add("Audi");
            carTypePicker.Items.Add("BMW");
            carTypePicker.Items.Add("Buick");
            carTypePicker.Items.Add("Cadillac");
            carTypePicker.Items.Add("Chevrolet");
            carTypePicker.Items.Add("Dodge");
            carTypePicker.Items.Add("Fiat");
            carTypePicker.Items.Add("Ford");
            carTypePicker.Items.Add("GMC");
            carTypePicker.Items.Add("Honda");
            carTypePicker.Items.Add("Hyundai");
            carTypePicker.Items.Add("Jeep");
            carTypePicker.Items.Add("Kia");
            carTypePicker.Items.Add("Mazda");
            carTypePicker.Items.Add("Mitsubishi");
            carTypePicker.Items.Add("Nissan");
            carTypePicker.Items.Add("Renault");
            carTypePicker.Items.Add("Toyota");
            carTypePicker.Items.Add("VolksWagen");
        }
    }
}