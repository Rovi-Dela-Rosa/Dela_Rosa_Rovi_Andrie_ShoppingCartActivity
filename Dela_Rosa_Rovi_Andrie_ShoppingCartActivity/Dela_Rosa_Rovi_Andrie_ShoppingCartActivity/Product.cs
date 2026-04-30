using System;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int RemainingStock { get; set; }

        // For cart
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