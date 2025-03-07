// Models/OrderLineItem.cs
using System;
using System.ComponentModel;

namespace BarManagementSystem.Models
{
    public class OrderLineItem : INotifyPropertyChanged
    {
        private int orderId;
        private int itemId;
        private MenuItem menuItem;
        private string selectedType;
        private int quantity;
        private string price;
        private string amount;
        private string kot;

        public int OrderId
        {
            get => orderId;
            set { orderId = value; OnPropertyChanged(nameof(OrderId)); }
        }

        public int ItemId
        {
            get => itemId;
            set { itemId = value; OnPropertyChanged(nameof(ItemId)); }
        }

        public MenuItem MenuItem
        {
            get => menuItem;
            set { menuItem = value; OnPropertyChanged(nameof(MenuItem)); }
        }

        public string SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                UpdatePrice();
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                UpdateAmount();
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public string Price
        {
            get => price;
            set { price = value; OnPropertyChanged(nameof(Price)); }
        }

        public string Amount
        {
            get => amount;
            set { amount = value; OnPropertyChanged(nameof(Amount)); }
        }

        public string KOT
        {
            get => kot;
            set { kot = value; OnPropertyChanged(nameof(KOT)); }
        }

        private void UpdatePrice()
        {
            if (menuItem != null && !string.IsNullOrEmpty(selectedType))
            {
                string[] types = menuItem.Types.Split(',');
                string[] prices = menuItem.Prices.Split(',');
                int index = Array.IndexOf(types, selectedType);
                if (index >= 0 && index < prices.Length)
                {
                    Price = prices[index].Replace("rs", "").Trim();
                    UpdateAmount();
                }
            }
        }

        private void UpdateAmount()
        {
            if (!string.IsNullOrEmpty(price) && double.TryParse(price, out double priceValue))
            {
                Amount = (quantity * priceValue).ToString("F2");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}