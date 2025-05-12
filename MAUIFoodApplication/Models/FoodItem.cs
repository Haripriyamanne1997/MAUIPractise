using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MAUIFoodApplication.Models
{
    public class FoodItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                if (_isFavorite != value)
                {
                    _isFavorite = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FavoriteIcon));
                }
            }
        }

        public string FavoriteIcon => IsFavorite ? "heart_filled.png" : "heart_outline.png";

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsAddToCartVisible));
                    OnPropertyChanged(nameof(IsQuantityControlVisible));
                }
            }
        }

        public bool IsAddToCartVisible => Quantity == 0;
        public bool IsQuantityControlVisible => Quantity > 0;

        // Reusable command instances
        public ICommand AddToCartCommand { get; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }

        public FoodItem()
        {
            AddToCartCommand = new Command(() => Quantity = 1);
            IncrementCommand = new Command(() => Quantity++);
            DecrementCommand = new Command(() =>
            {
                if (Quantity > 0)
                    Quantity--;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
