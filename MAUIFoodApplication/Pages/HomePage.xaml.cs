using MAUIFoodApplication.Models;
using MAUIFoodApplication.ViewModels;
using MAUIFoodApplication.Services;

namespace MAUIFoodApplication.Pages
{
    public partial class HomePage : ContentPage
    {
        private HomePageViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            viewModel = new HomePageViewModel();
            BindingContext = viewModel;
        }

        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton btn && btn.BindingContext is FoodItem item)
            {
                item.IsFavorite = !item.IsFavorite;
            }
        }

        private async void OnCartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }

        private void OnIncreaseClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is FoodItem item)
            {
                item.Quantity++;
            }
        }

        private void OnDecreaseClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is FoodItem item)
            {
                if (item.Quantity > 0)
                    item.Quantity--;
            }
        }

        private void OnAddToCartClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var foodItem = button?.BindingContext as FoodItem;

            if (foodItem != null && foodItem.Quantity > 0)
            {
                CartService.Instance.AddToCart(foodItem);
                foodItem.Quantity = 0; // optional: reset after adding
            }
        }

    }
}
