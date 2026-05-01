using System;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    internal class Order
    {
        public string ReceiptNumber { get; set; }
        public string CheckoutDate { get; set; }
        public double FinalTotal { get; set; }
        public double Payment { get; set; }
        public double Change { get; set; }



        public static Order[] History = new Order[50];
        public static int HistoryCount = 0;

        public static void ShowMenu()
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("--- SHOPPING CART SYSTEM ---");
            Console.WriteLine("----------------------------");
            Console.WriteLine("\n>>> SYSTEM MENU <<<");
            Console.WriteLine("\n1. Add Product to Bag");
            Console.WriteLine("2. Search Product");
            Console.WriteLine("3. Filter by Category");
            Console.WriteLine("4. View Bag");
            Console.WriteLine("5. Remove Item");
            Console.WriteLine("6. Update Quantity");
            Console.WriteLine("7. Clear Bag");
            Console.WriteLine("8. Checkout");
            Console.WriteLine("9. View Order History");
            Console.WriteLine("10. Exit");
        }

        public static void AddOrder(Order order)
        {
            History[HistoryCount] = order;
            HistoryCount++;
        }

        public static void ViewHistory()
        {
            Console.WriteLine("\n>>> ORDER HISTORY <<<");

            if (HistoryCount == 0)
            {
                Console.WriteLine("No completed transactions yet.");
                return;
            }

            for (int i = 0; i < HistoryCount; i++)
            {
                Console.WriteLine(
                    $"Receipt #{History[i].ReceiptNumber} - Final Total: P{History[i].FinalTotal}");
            }
        }
    }
}
