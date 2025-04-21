using System;
using Microsoft.Maui.Controls;

namespace MAUIFoodApplication.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter email and password.", "OK");
                return;
            }

            var storedEmail = Preferences.Get("Email", string.Empty);
            var storedPassword = Preferences.Get("Password", string.Empty);

            if (email == storedEmail && password == storedPassword)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                // Navigate to your main page or dashboard
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid credentials.", "OK");
            }
        }
    }
}
