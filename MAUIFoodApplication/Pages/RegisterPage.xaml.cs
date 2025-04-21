namespace MAUIFoodApplication.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var firstName = FirstNameEntry.Text;
        var lastName = LastNameEntry.Text;
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;
        var confirmPassword = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        // Simulate storing user data
        Preferences.Set("Email", email);
        Preferences.Set("Password", password);

        await DisplayAlert("Success", "Registration successful!", "OK");

        // Navigate to login page
        await Navigation.PushAsync(new LoginPage());
    }
}