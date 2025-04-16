using Android.Widget;
using MAUIFoodApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Application = Android.App.Application;

namespace MAUIFoodApplication.Platforms.Android
{
    public class PlatformService : IPlatformService
    {
        public void ShowToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short)?.Show();
        }
    }
}
