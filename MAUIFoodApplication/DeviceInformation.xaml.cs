using System.Xml;

namespace MAUIFoodApplication;

public partial class DeviceInformation : ContentPage
{
    public DeviceInformation()
    {
        InitializeComponent();
        LoadDeviceInfo();
    }

    private void LoadDeviceInfo()
    {
        ModelLabel.Text = $"Model: {DeviceInfo.Model}";
        ManufacturerLabel.Text = $"Manufacturer: {DeviceInfo.Manufacturer}";
        NameLabel.Text = $"Name: {DeviceInfo.Name}";
        PlatformLabel.Text = $"Platform: {DeviceInfo.Platform}";
        VersionLabel.Text = $"Version: {DeviceInfo.VersionString}";
        IdiomLabel.Text = $"Idiom: {DeviceInfo.Idiom}";
        DeviceTypeLabel.Text = $"Device Type: {DeviceInfo.DeviceType}";
    }
}