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
            Console.WriteLine("--- SHOPPING CART SYSTEM ---");


            Product[] bmenu = new Product[]
            {
                new Product {Id = 1, Name = "Billabong Shorts", Price = 950.00, RemainingStock = 15},    
                new Product {Id = 2, Name = "Nike Air Max", Price = 6500.00, RemainingStock = 10},      
                new Product {Id = 3, Name = "Polo Plain Tee", Price = 650.00, RemainingStock = 25},
                new Product {Id = 4, Name = "Adidas Crew Socks", Price = 299.00, RemainingStock = 30},
                new Product {Id = 5, Name = "Nike Tank Top", Price = 199.00, RemainingStock = 9}
            };

            Product[] bag = new Product[100];                              // i create new array of object (bag) using the former array to store an item with limited
                                                                           // to 100 bags.
            int bagCount = 0;                                              

            var choice = "Yes";

            while (choice == "Yes")
            {

                Console.WriteLine("----------------------------");

                Console.WriteLine("--- STORE MENU ---");
                Console.WriteLine("\nID | NAME | PRICE | STOCK");

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
                    Console.WriteLine("Apologies, product is out of stock.");          // invalidation of user to buy an out of stock product.
                    continue;
                }

                if (!picked.HasEnoughStock(quanti))
                {
                    Console.WriteLine("Not enough stock for your purchase. Only " + picked.RemainingStock + " left in stock."); // accessing the method i created in class product, then 
                    continue;                                                                                                   // preventing user to purchase an item greater than remaining
                }                                                                                                               // stock.

                bag[bagCount] = new Product { Id = picked.Id, Name = picked.Name, Price = picked.Price, RemainingStock = quanti };

                picked.RemainingStock -= quanti;
                bagCount++;
                Console.WriteLine("The item was added to bag!");

                Console.WriteLine("Do you want to purchase more item? (YES/NO)");
                choice = Console.ReadLine().ToUpper();



            }
           
        }
    }
}