using System;
using System.Collections.Generic;
using System.Text;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    public class Product
    {
        public int Id { get; set; }                   
        public string Name { get; set; }                   
        public double Price { get; set; }             
        public int RemainingStock { get; set; }

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id}. {Name} - P{Price} (Stock: {RemainingStock})"); 
        }                                                                             

        public bool HasEnoughStock(int quantity)      
        {
            return RemainingStock >= quantity;
        }

    }
}