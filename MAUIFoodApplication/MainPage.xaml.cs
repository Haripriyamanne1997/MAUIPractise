using MAUIFoodApplication.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection; // Required for GetService
using MAUIFoodApplication;

namespace MAUIFoodApplication
{
    public partial class MainPage : ContentPage
    {
        private readonly IDeviceService _deviceService;
        private readonly IPlatformService _platformService;

        public MainPage(IDeviceService deviceService,IPlatformService platformService)
        {
            InitializeComponent();
            _deviceService = deviceService;
            DeviceLabel.Text = _deviceService.GetsPlatformName();
            _platformService = platformService;
        }
       
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnDeviceInformationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceInformation());
        }
        private async void OnDeviceSensorsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceSensors());
        }
        private async void OnInvokePlatformCodeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InvokePlatformCode(_platformService));
        }

    }
}
