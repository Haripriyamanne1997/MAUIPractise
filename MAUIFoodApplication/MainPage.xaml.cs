using MAUIFoodApplication.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection; // Required for GetService
using MAUIFoodApplication;
using MAUIFoodApplication.Pages;

namespace MAUIFoodApplication
{
    public partial class MainPage : ContentPage
    {
        private readonly IDeviceService _deviceService;
        private readonly IPlatformService _platformService;

        public MainPage(IDeviceService deviceService, IPlatformService platformService)
        {
            InitializeComponent();
            _deviceService = deviceService;
            DeviceLabel.Text = _deviceService.GetsPlatformName(); // Assuming method returns platform name.
            _platformService = platformService;
        }

        // Register Click Handler
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        // Device Information Click Handler
        private async void OnDeviceInformationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceInformation());
        }

        // Device Sensors Click Handler
        private async void OnDeviceSensorsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceSensors());
        }

        // Invoke Platform Code Click Handler
        private async void OnInvokePlatformCodeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InvokePlatformCode(_platformService));
        }

        //Permission code
        private async void OnPermissionsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PermissionPage());
        }

        //Preferences
        private async void OnPreferencesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PreferencesPage());
        }

        //Settings Page
        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
