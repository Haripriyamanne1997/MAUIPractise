using MAUIFoodApplication.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection; // Required for GetService

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
    }
}
