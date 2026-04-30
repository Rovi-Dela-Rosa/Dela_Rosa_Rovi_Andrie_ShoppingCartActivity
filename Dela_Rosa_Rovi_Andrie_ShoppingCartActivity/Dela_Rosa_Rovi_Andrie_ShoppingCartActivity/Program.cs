using Dela_Rosa_Rovi_Andrie_ShoppingCartActivity;
using System;

namespace ShoppingCartActivity
{
    class Quiz
    {
        static void ShowMenu()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("--- SHOPPING CART SYSTEM ---");
            Console.WriteLine("----------------------------");
            Console.WriteLine("\n--- SYSTEM MENU ---");
            Console.WriteLine("\n1. Add Product to Cart");
            Console.WriteLine("2. Search Product");
            Console.WriteLine("3. Filter by Category");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Remove Item");
            Console.WriteLine("6. Update Quantity");
            Console.WriteLine("7. Clear Cart");
            Console.WriteLine("8. Checkout");
            Console.WriteLine("9. Exit");
        }

        static void AddProductMenu(Product[] bmenu, Cart bag)
        {
            Console.WriteLine("\n--- STORE MENU ---");

            foreach (var p in bmenu)
                p.DisplayProduct();

            Console.Write("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id < 1 || id > bmenu.Length)
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            Product picked = bmenu[id - 1];

            if (!picked.HasEnoughStock(qty))
            {
                Console.WriteLine("Not enough stock.");
                return;
            }

            if (!bag.AddToCart(picked, qty))
                Console.WriteLine("The cart is full.");
        }

        static void SearchProductMenu(Product[] bmenu)
        {
            Console.Write("Search: ");
            string search = Console.ReadLine().ToLower();

            foreach (var p in bmenu)
            {
                if (p.Name.ToLower().Contains(search))
                    p.DisplayProduct();
            }
        }

        static void CategoryMenu(Product[] bmenu)
        {
            Console.WriteLine("\n--- PRODUCT CATEGORIES ---");
            Console.WriteLine("1. Topwear\n2. Bottomwear\n3. Footwear\n4. Accesories");
            Console.Write("Choose: ");

            if (!int.TryParse(Console.ReadLine(), out int c))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            string cat = "";

            switch (c)
            {
                case 1:
                    cat = "Topwear";
                    break;

                case 2:
                    cat = "Bottomwear";
                    break;

                case 3:
                    cat = "Footwear";
                    break;

                case 4:
                    cat = "Accessories";
                    break;

                default:
                    Console.WriteLine("Invalid category.");
                    return;
            }

            Console.WriteLine($"\n--- {cat.ToUpper()} ---");

            bool found = false;

            foreach (var p in bmenu)
            {
                if (p.Category == cat)
                {
                    p.DisplayProduct();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Can't find the product.");
            }
        }

        public static void Main(string[] args)
        {
            Product[] bmenu = new Product[]
            {
                new Product { Id = 1, Name = "Billabong Shorts", Category = "Bottomwear", Price = 950.00, RemainingStock = 15 },
                new Product { Id = 2, Name = "Nike Air Max", Category = "Footwear", Price = 6500.00, RemainingStock = 10 },
                new Product { Id = 3, Name = "Polo Plain Tee", Category = "Topwear", Price = 650.00, RemainingStock = 25 },
                new Product { Id = 4, Name = "Chrome Hearts Bracelet", Category = "Accessories", Price = 4500.00, RemainingStock = 8 },
                new Product { Id = 5, Name = "Nike Tank Top", Category = "Topwear", Price = 199.00, RemainingStock = 9 }
            };

            Cart bag = new Cart();

            while (true)
            {
                ShowMenu();

                Console.Write("Choose an option: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                    continue;

                switch (choice)
                {
                    case 1: AddProductMenu(bmenu, bag); break;
                    case 2: SearchProductMenu(bmenu); break;
                    case 3: CategoryMenu(bmenu); break;
                    case 4: bag.ViewCart(); break;

                    case 5:
                        Console.Write("ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int rid))
                            Console.WriteLine(bag.RemoveItem(rid) ? "Removed." : "Not found.");
                        break;

                    case 6:
                        Console.Write("ID: ");
                        int uid;
                        int qty;

                        if (int.TryParse(Console.ReadLine(), out uid))
                        {
                            Console.Write("New Qty: ");
                            if (int.TryParse(Console.ReadLine(), out qty))
                                Console.WriteLine(bag.UpdateQuantity(uid, qty) ? "Updated." : "Failed.");
                        }
                        break;

                    case 7: bag.ClearCart(); break;

                    case 8:
                        bag.DisplayReceipt();
                        Console.WriteLine("\n--- UPDATED STOCK ---");
                        foreach (var p in bmenu)
                            Console.WriteLine($"{p.Name}: {p.RemainingStock}");
                        break;

                    case 9: return;
                }
            }
        }
    }
}