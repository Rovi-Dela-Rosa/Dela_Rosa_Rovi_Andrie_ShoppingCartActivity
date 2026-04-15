using Dela_Rosa_Rovi_Andrie_ShoppingCartActivity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartActivity
{
    class Quiz
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- SHOPPING CART SYSTEM ---");


            Product[] menu = new Product[]
            {
                new Product {Id = 1, Name = "Billabong Shorts", Price = 950.00, RemainingStock = 15},    
                new Product {Id = 2, Name = "Nike Air Max", Price = 6500.00, RemainingStock = 10},      
                new Product {Id = 3, Name = "Polo Plain Tee", Price = 650.00, RemainingStock = 25},
                new Product {Id = 4, Name = "Adidas Crew Socks", Price = 299.00, RemainingStock = 30},
                new Product {Id = 5, Name = "Nike Tank Top", Price = 199.00, RemainingStock = 9}
            };

            string choice = "Yes";
            while (choice == "Yes")
            {

                Console.WriteLine("----------------------------");

                Console.WriteLine("--- STORE MENU ---");
                Console.WriteLine("\nID | NAME | PRICE | STOCK");

                foreach (Product bclothes in menu)
                {
                    bclothes.DisplayProduct();
                }

                int order;
                int quanti;

                Console.Write("\nEnter product number (ID) : ");                                        // i create user input and use .TryParse for input validation
                if (!int.TryParse(Console.ReadLine(), out order) || order < 1 || order > menu.Length)   // and convertion for these 2 new variable.
                {
                    Console.WriteLine("Invalid product number (ID)! Please enter the correct ID.");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out quanti) || quanti <= 0)
                {
                    Console.WriteLine("Invalid quatity! Try again.");
                    continue;
                }


            }
           
        }
    }
}