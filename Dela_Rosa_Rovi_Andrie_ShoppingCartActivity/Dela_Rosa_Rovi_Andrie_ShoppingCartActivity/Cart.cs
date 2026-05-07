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
            Console.WriteLine("\n>>> YOUR CART <<<");

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
            if (newQty <= 0)
                return false;

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

        public void ClearBag()
        {
            if (bagCount == 0)
            {
                Console.WriteLine("The bag is already empty.");
                return;
            }

            for (int i = 0; i < bagCount; i++)
            {
                bag[i].OriginalProduct.AddStock(bag[i].QuantityBought);
                bag[i] = null;
            }

            bagCount = 0;
            Console.WriteLine("Your cart was cleared.");
        }

        public void LowkeyClearBag()
        {
            for (int i = 0; i < bagCount; i++)
            {
                bag[i] = null;
            }

            bagCount = 0;

        }

        public bool ItsEmpty()
        {
            return bagCount == 0;
        }

        public double TakeGrandTotal()
        {
            double total = 0;

            for (int i = 0; i < bagCount; i++)
            {
                total += bag[i].GetItemTotal(bag[i].QuantityBought);
            }

            return total;
        }

        public double TakeDiscount()
        {
            double total = TakeGrandTotal();

            if (total >= 5000)
                return total * 0.10;

            return 0;
        }

        public void DisplayReceipt(string receiptNo, string dateNow, double PAYMENT, double CHANGE)
        {
            Console.WriteLine("\n>>> FINAL RECEIPT <<<");
            Console.WriteLine("Receipt No: " + receiptNo);
            Console.WriteLine("Date: " + dateNow);

            double GRANDTOTAL = TakeGrandTotal();
            double DISCOUNT = TakeDiscount();
            double TOTALALIZATION = GRANDTOTAL - DISCOUNT;

            for (int i = 0; i < bagCount; i++)
            {
                double Ltotal = bag[i].GetItemTotal(bag[i].QuantityBought);
                Console.WriteLine($"{bag[i].Name} x {bag[i].QuantityBought} - P{Ltotal}");
            }

            Console.WriteLine($"Grand Total: P{GRANDTOTAL}");
            Console.WriteLine($"Discount: P{DISCOUNT}");
            Console.WriteLine($"Final Total: P{TOTALALIZATION}");
            Console.WriteLine($"Payment: P{PAYMENT}");
            Console.WriteLine($"Change: P{CHANGE}");

        }
    }
}
