using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIFoodApplication.Interfaces;

namespace MAUIFoodApplication.Platforms.Windows
{
    public class DeviceService : IDeviceService
    {
        public string GetsPlatformName() => "Windows Device";
    }
}
