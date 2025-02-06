using MAUIFoodApplication.Interfaces;

namespace MAUIFoodApplication.Platforms.Android
{
    public class DeviceService : IDeviceService
    {
        public string GetsPlatformName() => "Android Device";
    }

}
