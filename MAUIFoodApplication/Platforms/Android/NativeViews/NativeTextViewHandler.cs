using Android.Content;
using Android.Widget;
using Microsoft.Maui.Handlers;
using Android.Graphics;
using Android.Util;
using Microsoft.Maui;
using Color = Android.Graphics.Color;

namespace MAUIFoodApplication.Platforms.Android.NativeViews
{
    public class NativeTextViewHandler : ViewHandler<Label, TextView>
    {
        public NativeTextViewHandler() : base(Mapper)
        {
        }

        public static IPropertyMapper<Label, NativeTextViewHandler> Mapper =
            new PropertyMapper<Label, NativeTextViewHandler>(ViewHandler.ViewMapper);

        protected override TextView CreatePlatformView()
        {
            var textView = new TextView(Context);
            textView.Text = "Hello from Native Android TextView!";
            textView.SetTextColor(Color.Red);
            textView.SetTextSize(ComplexUnitType.Sp, 20);
            return textView;
        }
    }
}
