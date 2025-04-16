using MAUIFoodApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace MAUIFoodApplication.Platforms.iOS
{
    public class PlatformService : IPlatformService
    {
        public void ShowToast(string message)
        {
            var alert = new UIAlertView()
            {
                Title = "iOS Toast",
                Message = message
            };
            alert.AddButton("OK");
            alert.Show();
        }
    }
}
