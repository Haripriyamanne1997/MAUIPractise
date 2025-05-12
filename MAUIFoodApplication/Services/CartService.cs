using MAUIFoodApplication.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MAUIFoodApplication.Services
{
    public class CartService
    {
        private static CartService cartservice;
        public static CartService Instance => cartservice ??= new CartService();

        public ObservableCollection<FoodItem> CartItems { get; } = new();

        public void AddToCart(FoodItem item)
        {
            var existingItem = CartItems.FirstOrDefault(x => x.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                CartItems.Add(new FoodItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ImageUrl = item.ImageUrl
                });
            }
        }

        public decimal Total => CartItems.Sum(i => i.Price * i.Quantity);

        public void ClearCart() => CartItems.Clear();
    }
}
