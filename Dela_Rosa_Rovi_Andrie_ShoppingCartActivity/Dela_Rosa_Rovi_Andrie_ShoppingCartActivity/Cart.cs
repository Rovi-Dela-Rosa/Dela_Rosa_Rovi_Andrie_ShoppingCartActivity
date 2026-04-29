using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    public class Cart 
    {
        private Product[] bag = new Product[1];  
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

            if (bagCount >= bag.Length) 
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

        public void ViewCart()
        {
            Console.WriteLine("\n--- YOUR CART ---");

            if (bagCount == 0)
            {
                Console.WriteLine("Your bag is empty."); 
                return;
            }
            
            for (int i = 0; i < bagCount; i++)
            {
                double stotal = bag[i].GetItemTotal(bag[i].QuantityBought);

                Console.WriteLine($"{bag[i].Id}. {bag[i].Name} x{bag[i].QuantityBought} - P{stotal}");
            }
        
        }
        public bool RemoveItem (int id)
        {
            for(int i = 0; i < bagCount; i++)
            {
                if (bag[i].Id == id)
                {
                    for (int j = i; j < bagCount; j++)
                    {
                        bag[j] = bag[j + 1];
                    }

                    bag[bagCount - 1] = null;
                    bagCount--;

                    return true;
                }
            }

            return false;
        }

        public void ClearBag()
        {
            for (int i = 0; i < bagCount; i++)
            {
                bag[i] = null;
            }

            bagCount = 0;

            Console.WriteLine("Your cart was cleared.");
        }

        public bool UpdateQuantt(int id, int newQuantt)
        {
            for (int i = 0; i < bagCount; i++)
            {
                if (bag[i].Id == id)
                {
                    bag[i].QuantityBought = newQuantt;
                    return true;
                }
            }

            return false;
        }
    }

}
