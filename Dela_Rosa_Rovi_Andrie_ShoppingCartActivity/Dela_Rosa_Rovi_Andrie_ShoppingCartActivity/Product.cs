using System;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        private double price;
        private int remainingstock; 
        
        public double Price                       //since i already have an encapsulation (getters & setters) in the first place i js converted these 2 product data
        {                                         // into private modifiers fields (much controlled) to protect stock and price by preventing invalid negative assignments.
            get { return price; }
            set
            {
                if (value >= 0)
                    price = value;
            }
        }

        public int RemainingStock
        {
            get { return remainingstock; }
            set
            {
                if (value >= 0)
                    remainingstock = value;
            }
        }

        public int QuantityBought { get; set; }
        public Product OriginalProduct { get; set; }

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id}. {Name} ({Category}) - P{Price} (Stock: {RemainingStock})");
        }

        public bool HasEnoughStock(int quantity)
        {
            return RemainingStock >= quantity;
        }

        public double GetItemTotal(int quantity)
        {
            return Price * quantity;
        }

        public void DeductStock(int quantity)
        {
            RemainingStock -= quantity;
        }

        public void AddStock(int quantity)
        {
            RemainingStock += quantity;
        }
    }
}