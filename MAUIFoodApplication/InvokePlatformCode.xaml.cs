namespace MAUIFoodApplication;
using Microsoft.Extensions.DependencyInjection;
using MAUIFoodApplication.Interfaces;

public partial class InvokePlatformCode : ContentPage
{
    private readonly IPlatformService _platformService;
    public InvokePlatformCode(IPlatformService platformService)
	{
		InitializeComponent();
        _platformService = platformService;
    }
    private void OnCounterClicked(object sender, EventArgs e)
    {
        _platformService.ShowToast("Hello from native platform code");
    }
}