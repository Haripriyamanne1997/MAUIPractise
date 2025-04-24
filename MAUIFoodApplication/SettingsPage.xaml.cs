using Microsoft.Maui.Storage;

namespace MAUIFoodApplication;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        LoadPreferences();
    }

    private void LoadPreferences()
    {
        // Username
        usernameEntry.Text = Preferences.Get("username", string.Empty);

        // Theme
        var theme = Preferences.Get("appTheme", "light");
        themeSwitch.IsToggled = theme == "dark";
        themeLabel.Text = $"Theme: {theme}";

        // Notifications
        var notifications = Preferences.Get("notificationsEnabled", false);
        notificationSwitch.IsToggled = notifications;
        notificationLabel.Text = $"Notifications: {(notifications ? "On" : "Off")}";

        // Language
        string lang = Preferences.Get("language", "English");
        languagePicker.SelectedItem = lang;
        languageLabel.Text = $"Language: {lang}";
    }

    private void OnSaveUsernameClicked(object sender, EventArgs e)
    {
        Preferences.Set("username", usernameEntry.Text);
        DisplayAlert("Saved", "Username saved successfully", "OK");
    }

    private void OnThemeToggled(object sender, ToggledEventArgs e)
    {
        string theme = e.Value ? "dark" : "light";
        Preferences.Set("appTheme", theme);
        themeLabel.Text = $"Theme: {theme}";
    }

    private void OnNotificationToggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("notificationsEnabled", e.Value);
        notificationLabel.Text = $"Notifications: {(e.Value ? "On" : "Off")}";
    }

    private void OnLanguageChanged(object sender, EventArgs e)
    {
        if (languagePicker.SelectedItem is string selectedLang)
        {
            Preferences.Set("language", selectedLang);
            languageLabel.Text = $"Language: {selectedLang}";
        }
    }
}
