using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MAUIFoodApplication.Models;

namespace MAUIFoodApplication.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FoodItem> FoodItems { get; set; }

        private int cartCount;
        public int CartCount
        {
            get => cartCount;
            set
            {
                if (cartCount != value)
                {
                    cartCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public HomePageViewModel()
        {
            FoodItems = new ObservableCollection<FoodItem>
            {
                new FoodItem { Name = "Pizza", Price = 199, ImageUrl = "pizza.jpg" },
                new FoodItem { Name = "Burger", Price = 99, ImageUrl = "burger.jpg" },
                new FoodItem { Name = "Pasta", Price = 149, ImageUrl = "pasta.png" }
            };
        }

        public void AddToCart(FoodItem item)
        {
            CartCount += item.Quantity;
            //item.Quantity = 0; // Reset quantity after adding to cart
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
