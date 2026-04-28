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

            Cart bag = new Cart();

            var choice = "Y";

            while (choice == "Y")
            {

                Console.WriteLine("\n--- STORE MENU ---\n");
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
                if (!bag.AddToCart(picked, quanti))
                {
                    Console.WriteLine("Cart is full.");  // cart-full validation.
                    continue;
                }

                do
                {
                    Console.Write("Do you want to purchase more item? (Y/N): ");
                    choice = Console.ReadLine().ToUpper();

                    if (choice != "Y" && choice != "N")
                    {
                        Console.WriteLine("Invalid input! Enter Y (for continue) or N (for stop shopping) only."); // applied a much strict and clearer validations for while loop to avoid typing any letters other than "Y" and "N".
                    }

                } while (choice != "Y" && choice != "N");
                
            }

            bag.DisplayReceipt();

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