using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MAUIFoodApplication;

public partial class PermissionPage : ContentPage
{
	public PermissionPage()
	{
		InitializeComponent();
	}
    private async void OnCheckPermissionClicked(object sender, EventArgs e)
    {
        var status = await Permissions.CheckStatusAsync<LocationWhenInUse>();

        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<LocationWhenInUse>();
        }

        if (status == PermissionStatus.Granted)
        {
            ResultLabel.Text = "Location permission granted";
        }
        else if (status == PermissionStatus.Denied)
        {
            ResultLabel.Text = "Location permission denied";
        }
        else if (status == PermissionStatus.Disabled)
        {
            ResultLabel.Text = "Location is disabled on this device";
        }
    }

    private async void OnCheckCameraPermissionClicked(object sender, EventArgs e)
    {
        var status = await Permissions.CheckStatusAsync<Camera>();
        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Camera>();
        }

        ResultLabel.Text = status == PermissionStatus.Granted ? "Camera Permission Granted" : "Camera Permission Denied";
    }

    private async void OnCheckStoragePermissionClicked(object sender, EventArgs e)
    {
        var status = await Permissions.CheckStatusAsync<StorageRead>();
        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<StorageRead>();
        }

        ResultLabel.Text = status == PermissionStatus.Granted ? "Storage Permission Granted" : "Storage Permission Denied";
    }

    private async void OnCheckMicrophonePermissionClicked(object sender, EventArgs e)
    {
        var status = await Permissions.CheckStatusAsync<Microphone>();
        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Microphone>();
        }

        ResultLabel.Text = status == PermissionStatus.Granted ? "Microphone Permission Granted" : "Microphone Permission Denied";
    }

    private async void OnCheckContactsPermissionClicked(object sender, EventArgs e)
    {
        var status = await Permissions.CheckStatusAsync<ContactsRead>();
        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<ContactsRead>();
        }

        ResultLabel.Text = status == PermissionStatus.Granted ? "Contacts Permission Granted" : "Contacts Permission Denied";
    }
}