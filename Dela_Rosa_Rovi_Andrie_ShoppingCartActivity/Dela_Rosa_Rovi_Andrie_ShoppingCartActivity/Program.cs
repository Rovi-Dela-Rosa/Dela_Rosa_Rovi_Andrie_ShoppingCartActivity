using Dela_Rosa_Rovi_Andrie_ShoppingCartActivity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ShoppingCartActivity
{
    class Quiz
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("--- SHOPPING CART SYSTEM ---");
            Console.WriteLine("----------------------------");

            Product[] bmenu = new Product[]
            {
                new Product {Id = 1, Name = "Billabong Shorts", Price = 950.00, RemainingStock = 15},
                new Product {Id = 2, Name = "Nike Air Max", Price = 6500.00, RemainingStock = 10},
                new Product {Id = 3, Name = "Polo Plain Tee", Price = 650.00, RemainingStock = 25},
                new Product {Id = 4, Name = "Adidas Crew Socks", Price = 299.00, RemainingStock = 30},
                new Product {Id = 5, Name = "Nike Tank Top", Price = 199.00, RemainingStock = 9}
            };

            Product[] bag = new Product[5];                              
                                                                           
            int bagCount = 0;

            var choice = "Y";

            while (choice == "Y")
            {

                Console.WriteLine("\n--- STORE MENU ---");
                Console.WriteLine("\nID|   NAME   |   PRICE   |   STOCK");

                foreach (Product bclothes in bmenu)
                {
                    bclothes.DisplayProduct();
                }

                int order;
                int quanti;

                Console.Write("\nEnter product number (ID) : ");
                if (!int.TryParse(Console.ReadLine(), out order) || order < 1 || order > bmenu.Length)
                {
                    Console.WriteLine("Invalid product number (ID)! Please enter the correct ID.");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out quanti) || quanti <= 0)
                {
                    Console.WriteLine("Invalid quantity! Try again.");
                    continue;
                }

                Product picked = bmenu[order - 1];

                if (picked.RemainingStock == 0)
                {
                    Console.WriteLine("Apologies, product is out of stock.");
                    continue;
                }

                if (!picked.HasEnoughStock(quanti))
                {
                    Console.WriteLine("Not enough stock for your purchase. Only " + picked.RemainingStock + " left in stock.");
                    continue;
                }

                bag[bagCount] = new Product 
                {   
                    Id = picked.Id, 
                    Name = picked.Name, 
                    Price = picked.Price, 
                    RemainingStock = quanti 
                };

                picked.RemainingStock -= quanti;
                bagCount++;
                Console.WriteLine("The item was added to bag!");

                Console.WriteLine("\nDo you want to purchase more item? (Y - Yes/N - No)");
                choice = Console.ReadLine().ToUpper();

                
            }

            Console.WriteLine("\n--- FINAL RECEIPT ---");
            double Total = 0;

            for (int i = 0; i < bagCount; i++)
            {
                double lineTotal = bag[i].Price * bag[i].RemainingStock;
                Console.WriteLine($"{bag[i].Name} x{bag[i].RemainingStock} - P{lineTotal}");
                Total += lineTotal;
            }

            Console.WriteLine($"Grand Total: P{Total}");

            if (Total >= 5000)
            {
                double items_discount = Total * 0.10;
                Console.WriteLine($"Discount (10%): -P{items_discount}");
                Console.WriteLine($"TOTAL TO PAY: P{(Total - items_discount)}");
            }
            else
            {
                Console.WriteLine($"TOTAL TO PAY: P{Total}");
            }
            Console.WriteLine("\n--- UPDATED STOCK ---");
            foreach (var p in bmenu) 
            { 
                Console.WriteLine ($"{p.Name}: {p.RemainingStock} left"); 
            }

            Console.WriteLine("\nThank you for copping goods! (PRESS ANY KEY TO EXIT)");
            Console.ReadKey();
        }
           
    }
}