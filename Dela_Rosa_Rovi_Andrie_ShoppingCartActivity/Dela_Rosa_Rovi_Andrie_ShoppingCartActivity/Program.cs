using Dela_Rosa_Rovi_Andrie_ShoppingCartActivity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartActivity
{
    class Quiz
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- SHOPPING CART SYSTEM ---");


            Product[] menu = new Product[]
            {
                new Product {Id = 1, Name = "Billabong Shorts", Price = 950.00, RemainingStock = 15},    // I use array initializer to easy add a new product
                new Product {Id = 2, Name = "Nike Air Max", Price = 6500.00, RemainingStock = 10},       // and it's not limited by size.
                new Product {Id = 3, Name = "Polo Plain Tee", Price = 650.00, RemainingStock = 25},
                new Product {Id = 4, Name = "Adidas Crew Socks", Price = 299.00, RemainingStock = 30},
                new Product {Id = 5, Name = "Nike Tank Top", Price = 199.00, RemainingStock = 9}
            };

            Console.WriteLine("----------------------------");

            Console.WriteLine("--- CLOTHING MENU ---");
            Console.WriteLine("\nID | NAME | PRICE | STOCK");

            foreach (Product bclothes in menu) // Foreach for looping the menu.
            {
                bclothes.DisplayProduct();
            }

            
        }
    }
}