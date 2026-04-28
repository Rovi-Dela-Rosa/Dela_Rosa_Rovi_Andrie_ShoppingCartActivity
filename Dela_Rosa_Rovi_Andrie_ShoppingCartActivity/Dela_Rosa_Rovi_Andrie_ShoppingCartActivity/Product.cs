using System;
using System.Collections.Generic;
using System.Text;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int RemainingStock { get; set; }

        public int QuantityBought;

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id}. {Name} - P{Price} (Stock: {RemainingStock})");
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


            // applied the 2 required methods in product class addressing the lacking of requirements through comments in docs sheets. 
        }
    }
}