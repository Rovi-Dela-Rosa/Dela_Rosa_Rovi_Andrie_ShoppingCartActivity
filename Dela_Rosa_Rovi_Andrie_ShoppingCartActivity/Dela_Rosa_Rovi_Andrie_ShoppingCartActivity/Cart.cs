using System;
using System.Collections.Generic;
using System.Text;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    public class Cart // i made a new class for cart to avoid main class to get bombarded by codes.
    {
        private Product[] bag = new Product[1]; // cart array of product objects. 
        private int bagCount = 0;

        public bool AddToCart(Product picked, int quantity)
        {
            for (int i = 0; i < bagCount; i++)
            {
                if (bag[i].Id == picked.Id)
                {
                    bag[i].QuantityBought += quantity;
                    picked.DeductStock(quantity);

                    Console.WriteLine("Cart updated!");
                    return true;
                }
            }

            if (bagCount >= bag.Length) // updated the fixed-size bag / cart and applied the validations in main class.
            {
                return false;
            }

            bag[bagCount] = new Product
            {
                Id = picked.Id,
                Name = picked.Name,
                Price = picked.Price,
                QuantityBought = quantity
            };

            picked.DeductStock(quantity);
            bagCount++;

            Console.WriteLine("The item was added to bag!");
            return true;
        }

        public void DisplayReceipt()
        {
            Console.WriteLine("\n--- FINAL RECEIPT ---");

            double Total = 0;

            for (int i = 0; i < bagCount; i++)
            {
                double lineTotal = bag[i].GetItemTotal(bag[i].QuantityBought);

                Console.WriteLine($"{bag[i].Name} x{bag[i].QuantityBought} - P{lineTotal}");

                Total += lineTotal;
            }

            Console.WriteLine($"Grand Total: P{Total}");

            if (Total >= 5000)
            {
                double items_discount = Total * 0.10;

                Console.WriteLine($"Discount (10%): -P{items_discount}");
                Console.WriteLine($"TOTAL TO PAY: P{Total - items_discount}");
            }
            else
            {
                Console.WriteLine($"TOTAL TO PAY: P{Total}");
            }
        }
    }

}
