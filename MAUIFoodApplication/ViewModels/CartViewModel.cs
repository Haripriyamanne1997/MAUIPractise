using MAUIFoodApplication.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using MAUIFoodApplication.Services;

namespace MAUIFoodApplication.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FoodItem> CartItems { get; set; } = new();

        public CartViewModel()
        {
            CartItems = CartService.Instance.CartItems;
        }

        public decimal Total => CartService.Instance.Total;

        public event PropertyChangedEventHandler PropertyChanged;

        public decimal TotalAmount => CartItems.Sum(item => item.Price * item.Quantity);

        public void RemoveFromCart(FoodItem item)
        {
            if (CartItems.Contains(item))
            {
                CartItems.Remove(item);
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        public void IncreaseQuantity(FoodItem item)
        {
            item.Quantity++;
            OnPropertyChanged(nameof(TotalAmount));
            OnPropertyChanged(nameof(CartItems));
        }

        public void DecreaseQuantity(FoodItem item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
                OnPropertyChanged(nameof(TotalAmount));
                OnPropertyChanged(nameof(CartItems));
            }
        }

        public async Task PlaceOrderAsync()
        {
            await Task.Delay(500); // Simulate async operation
            CartItems.Clear();
            OnPropertyChanged(nameof(TotalAmount));
        }

        void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
