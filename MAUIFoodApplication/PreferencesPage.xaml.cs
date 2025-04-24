namespace MAUIFoodApplication;

public partial class PreferencesPage : ContentPage
{
	public PreferencesPage()
	{
		InitializeComponent();
        string username = Preferences.Get("username", string.Empty);
        if (!string.IsNullOrEmpty(username))
        {
            welcomeLabel.Text = $"Welcome back, {username}!";
        }
    }
    private void OnSaveClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        if (!string.IsNullOrWhiteSpace(username))
        {
            Preferences.Set("username", username);
            welcomeLabel.Text = $"Welcome, {username}!";
        }
    }
}