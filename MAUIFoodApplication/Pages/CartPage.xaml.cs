using MAUIFoodApplication.Models;
using MAUIFoodApplication.ViewModels;

namespace MAUIFoodApplication.Pages
{
    public partial class CartPage : ContentPage
    {
        private CartViewModel viewModel;

        public CartPage()
        {
            InitializeComponent();
            viewModel = new CartViewModel();
            BindingContext = viewModel;
        }

        private void OnRemoveItemClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.BindingContext is FoodItem item)
            {
                viewModel.RemoveFromCart(item);
            }
        }

        private void OnDecreaseQuantityClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is FoodItem item)
            {
                viewModel.DecreaseQuantity(item);
            }
        }

        private void OnIncreaseQuantityClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is FoodItem item)
            {
                viewModel.IncreaseQuantity(item);
            }
        }

        private async void OnPlaceOrderClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirm Order", "Do you want to place this order?", "Yes", "No");
            if (confirm)
            {
                await viewModel.PlaceOrderAsync();
                await DisplayAlert("Success", "Your order has been placed!", "OK");
                await Navigation.PopAsync(); // Navigate back to Home or previous page
            }
        }
    }
}
