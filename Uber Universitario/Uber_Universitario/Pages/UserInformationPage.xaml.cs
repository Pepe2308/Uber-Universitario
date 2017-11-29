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
        Users user;
		public UserInformationPage (Users user)
		{
			InitializeComponent ();
            string fullName = user.Name.ToString() +" " + user.LastName.ToString();
            string matricula = "Matricula: " + user.EnrollmentID.ToString();
            string email = "Correo electrónico: " + user.Email.ToString().ToLower();
            string celular = "Celular: " + user.PhoneNumber.ToString();
            string password = "Contraseña: *****";
            BindingContext = user;
            this.user = user;
            fullNameLabel.Text = fullName;
            enrollmentIDLabel.Text = matricula;
            emailLabel.Text = email;
            celphonLabel.Text = celular;
            passwordLabel.Text = password;

            passwordLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnPasswordLabelClicked()),
            });

            celphonLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnCellPhoneLabelClicked()),
            });


        }

        private async void OnCellPhoneLabelClicked()
        {
            await Navigation.PushAsync(new UpdatePhoneNumberPage(user));
        }

        private async void OnPasswordLabelClicked()
        {
            await DisplayAlert("alerta", "seleccionaste la contraseña", "nimodo");
            return;
        }
    }
}