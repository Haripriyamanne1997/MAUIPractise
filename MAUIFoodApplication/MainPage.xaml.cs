using MAUIFoodApplication.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection; // Required for GetService
using MAUIFoodApplication;

namespace MAUIFoodApplication
{
    public partial class MainPage : ContentPage
    {
        private readonly IDeviceService _deviceService;

        public MainPage(IDeviceService deviceService)
        {
            InitializeComponent();
            _deviceService = deviceService;

            DeviceLabel.Text = _deviceService.GetsPlatformName();
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnDeviceInformationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceInformation());
        }

    }
}
