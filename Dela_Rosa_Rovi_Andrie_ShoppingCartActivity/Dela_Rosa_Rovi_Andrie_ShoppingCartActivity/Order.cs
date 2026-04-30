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



        public static Order[] History = new Order[100];
        public static int HistoryCount = 0;

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
