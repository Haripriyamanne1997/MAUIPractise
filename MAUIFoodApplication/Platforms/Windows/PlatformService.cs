using MAUIFoodApplication.Interfaces;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Linq;
using System.Threading.Tasks;

namespace MAUIFoodApplication.Platforms.Windows
{
    public class PlatformService : IPlatformService
    {
        public void ShowToast(string message)
        {
            // Access the first window in the App
            var window = App.Current.Windows.FirstOrDefault();
            if (window != null)
            {
                // Get the native Window
                var nativeWindow = window.Handler.PlatformView as Microsoft.UI.Xaml.Window;

                if (nativeWindow != null)
                {
                    // Create the ContentDialog
                    var dialog = new ContentDialog
                    {
                        Title = "Windows Toast",
                        Content = message,
                        CloseButtonText = "OK"
                    };

                    // Check if the content is available and set XamlRoot accordingly
                    if (nativeWindow.Content != null)
                    {
                        dialog.XamlRoot = nativeWindow.Content.XamlRoot;
                    }

                    // Show the dialog
                    _ = dialog.ShowAsync(); // Fire and forget, no need for HWND
                }
            }
        }
    }
}
