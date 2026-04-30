using System;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    public class Cart
    {
        private Product[] bag = new Product[5];
        private int bagCount = 0;

        public bool AddToCart(Product picked, int quantity)
        {
            for (int i = 0; i < bagCount; i++)
            {
                if (bag[i].Id == picked.Id)
                {
                    if (!picked.HasEnoughStock(quantity))
                        return false;

                    bag[i].QuantityBought += quantity;
                    picked.DeductStock(quantity);
                    Console.WriteLine("Your cart was updated!");
                    return true;
                }
            }

            if (bagCount >= bag.Length)
                return false;

            bag[bagCount] = new Product
            {
                Id = picked.Id,
                Name = picked.Name,
                Category = picked.Category,
                Price = picked.Price,
                QuantityBought = quantity,
                OriginalProduct = picked
            };

            picked.DeductStock(quantity);
            bagCount++;

            Console.WriteLine("The item was added to cart!");
            return true;
        }

        public void ViewCart()
        {
            Console.WriteLine("\n--- YOUR CART ---");

            if (bagCount == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            for (int i = 0; i < bagCount; i++)
            {
                double subtotal = bag[i].GetItemTotal(bag[i].QuantityBought);
                Console.WriteLine($"{bag[i].Id}. {bag[i].Name} x{bag[i].QuantityBought} - P{subtotal}");
            }
        }

        public bool RemoveItem(int id)
        {
            for (int i = 0; i < bagCount; i++)
            {
                if (bag[i].Id == id)
                {
                    bag[i].OriginalProduct.AddStock(bag[i].QuantityBought);

                    for (int j = i; j < bagCount - 1; j++)
                        bag[j] = bag[j + 1];

                    bag[bagCount - 1] = null;
                    bagCount--;

                    return true;
                }
            }
            return false;
        }

        public bool UpdateQuantity(int id, int newQty)
        {
            for (int i = 0; i < bagCount; i++)
            {
                if (bag[i].Id == id)
                {
                    int oldQty = bag[i].QuantityBought;
                    int diff = newQty - oldQty;

                    if (diff > 0)
                    {
                        if (!bag[i].OriginalProduct.HasEnoughStock(diff))
                        {
                            Console.WriteLine("Not enough stock.");
                            return false;
                        }

                        bag[i].OriginalProduct.DeductStock(diff);
                    }
                    else if (diff < 0)
                    {
                        bag[i].OriginalProduct.AddStock(-diff);
                    }

                    bag[i].QuantityBought = newQty;
                    return true;
                }
            }
            return false;
        }

        public void ClearCart()
        {
            for (int i = 0; i < bagCount; i++)
            {
                bag[i].OriginalProduct.AddStock(bag[i].QuantityBought);
                bag[i] = null;
            }

            bagCount = 0;
            Console.WriteLine("Your cart was cleared.");
        }

        public void DisplayReceipt()
        {
            Console.WriteLine("\n--- FINAL RECEIPT ---");

            if (bagCount == 0)
            {
                Console.WriteLine("The cart is empty.");
                return;
            }

            double total = 0;

            for (int i = 0; i < bagCount; i++)
            {
                double lineTotal = bag[i].GetItemTotal(bag[i].QuantityBought);
                Console.WriteLine($"{bag[i].Name} x{bag[i].QuantityBought} - P{lineTotal}");
                total += lineTotal;
            }

            Console.WriteLine($"Grand Total: P{total}");

            if (total >= 5000)
            {
                double discount = total * 0.10;
                Console.WriteLine($"Discount (10%): -P{discount}");
                Console.WriteLine($"TOTAL TO PAY: P{total - discount}");
            }
            else
            {
                Console.WriteLine($"TOTAL TO PAY: P{total}");
            }
        }
    }
}
