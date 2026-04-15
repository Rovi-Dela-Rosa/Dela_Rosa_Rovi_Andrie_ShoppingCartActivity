using System;
using System.Collections.Generic;
using System.Text;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    public class Product
    {
        public int Id { get; set; }                   // I use automatic properties for automatically creating
        public string Name { get; set; }              // Field and Encapsulation. Also, I put "public" (as my modifier)         
        public double Price { get; set; }             // for me/you to access it in another class (which is the main class).   
        public int RemainingStock { get; set; }

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id}. {Name} - P{Price} (Stock: {RemainingStock})"); // Put these for menu and use string interpolation for cleaner
        }                                                                             // arrangement of field.

        public bool HasEnoughStock(int quantity)     // Set bool as return type and add a return. 
        {
            return RemainingStock >= quantity;
        }

    }
}