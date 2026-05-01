using Dela_Rosa_Rovi_Andrie_ShoppingCartActivity;
using System;

namespace Dela_Rosa_Rovi_Andrie_ShoppingCartActivity
{
    class Quiz
    {
        static int receiptCounter = 1;
        static void AddProductMenu(Product[] bmenu, Cart bag)
        {
            Console.WriteLine("\n>>> STORE MENU <<<");

            foreach (var p in bmenu)
                p.DisplayProduct();

            Console.Write("Enter product number (ID): ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id < 1 || id > bmenu.Length)
            {
                Console.WriteLine("Invalid ID. Please enter the correct ID.");
                return;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity! Try again.");
                return;
            }

            Product picked = bmenu[id - 1];

            if (!picked.HasEnoughStock(qty))
            {
                Console.WriteLine("Not enough stock for your purchase.");
                return;
            }

            if (!bag.AddToCart(picked, qty))
            {
                Console.WriteLine("The cart is full.");
            }
            else
            {
                if (AskYorN("Add another item? (Y/N): "))
                {
                    AddProductMenu(bmenu, bag);
                }
            }
        }

        static void SearchProductMenu(Product[] bmenu)
        {
            Console.Write("Enter a product name to search: ");
            string search = Console.ReadLine().ToLower();

            bool found = false;

            Console.WriteLine("Result: ");

            foreach (var p in bmenu)
            {
                if (p.Name.ToLower().Contains(search))
                {
                    p.DisplayProduct();
                    found = true;
                }

            }

            if (!found)
            {
                Console.WriteLine("No matching product found / Not existing product.");
            }

        }

        static void CategoryMenu(Product[] bmenu)
        {
            Console.WriteLine("\n>>> PRODUCT CATEGORIES <<<");
            Console.WriteLine("1. Topwear" +
                "\n2. Bottomwear" +
                "\n3. Footwear" +
                "\n4. Accessories");

            Console.Write("Choose a category: ");

            if (!int.TryParse(Console.ReadLine(), out int c))
            {
                Console.WriteLine("Invalid input! Try again.");
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
                    Console.WriteLine("Invalid category! Try again.");
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

        static void ShowLowStock(Product[] bmenu)
        {
            Console.WriteLine("\n>>> LOW STOCK ALERT <<<");
            bool found = false;

            foreach (var p in bmenu)
            {
                if (p.RemainingStock <= 5)
                {
                    Console.WriteLine($"{p.Name} has only {p.RemainingStock} stocks left.");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No low stock items.");
        }

        static void CheckoutMenu(Product[] bmenu, Cart bag)
        {
            if (bag.ItsEmpty())
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            double grandTotal = bag.TakeGrandTotal();
            double discount = bag.TakeDiscount();
            double finalTotal = grandTotal - discount;

            double payment;

            while (true)
            {
                Console.WriteLine($"\nFinal Total: P{finalTotal}");
                Console.Write("Enter payment: ");

                if (!double.TryParse(Console.ReadLine(), out payment))
                {
                    Console.WriteLine("Payment Error! (Payment must be numeric) ");
                    continue;
                }

                if (payment < finalTotal)
                {
                    Console.WriteLine("Insufficient payment. (Enter a right amount) ");
                    continue;
                }

                break;
            }

            double change = payment - finalTotal;

            string receiptNo = receiptCounter.ToString("D4");
            receiptCounter++;

            string dateNow = DateTime.Now.ToString("yyyy-MM-dd - hh:mm tt");

            bag.DisplayReceipt(receiptNo, dateNow, payment, change);

            Order.AddOrder(new Order
            {
                ReceiptNumber = receiptNo,
                CheckoutDate = dateNow,
                FinalTotal = finalTotal,
                Payment = payment,
                Change = change
            });

            bag.LowkeyClearBag();

            ShowLowStock(bmenu);

            Console.WriteLine("\nChecking out is successful. Thank you for copping goods!");

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
                Order.ShowMenu();

                Console.Write("\nChoose an option: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddProductMenu(bmenu, bag);
                        break;
                    case 2:
                        SearchProductMenu(bmenu);
                        break;
                    case 3:
                        CategoryMenu(bmenu);
                        break;
                    case 4:
                        bag.ViewCart();
                        break;

                    case 5:
                        while (true)
                        {
                            Console.Write("Enter ID to remove: ");

                            if (int.TryParse(Console.ReadLine(), out int rid))
                            {
                                Console.WriteLine("Invalid input! Please enter a numeric ID.");
                                continue;
                            }

                            if (!bag.RemoveItem(rid))
                            {
                                Console.WriteLine("Invalid input! Try again.");
                                continue;

                            }
                            Console.WriteLine("The item was succesfully removed.");
                            break;
                        }
                        break;
                    case 6:
                        int uid;
                        int qty;

                        while (true)
                        {
                            Console.Write("Enter ID: ");
                            if (!int.TryParse(Console.ReadLine(), out uid))
                            {
                                Console.WriteLine("Invalid input! Try again.");
                                continue;
                            }

                            Console.Write("New Quantity: ");
                            if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
                            {
                                Console.WriteLine("Quantity must be a positive number!");
                                continue;
                            }

                            bool updated = bag.UpdateQuantity(uid, qty);

                            if (!updated)
                            {
                                Console.WriteLine("Update failed. Either item not found or insufficient stock.");
                                continue;
                            }

                            Console.WriteLine("Quantity updated successfully.");
                            break;
                        }
                        break;

                    case 7:
                        if (AskYorN("Are you sure you want to clear your bag? (Y/N): "))
                        {
                            bag.ClearBag();
                        }
                        break;

                    case 8:
                        CheckoutMenu(bmenu, bag);
                        break;

                    case 9:
                        Order.ViewHistory();
                        break;

                    case 10:
                        if (AskYorN("Exit program? (Y/N): "))
                            return;
                        break;

                    default:
                        Console.WriteLine("Invalid MENU choice. Please try again.");
                        break;
                }
            }
        }
        public static bool AskYorN(string message)
        {
            while (true)
            {
                Console.Write(message);

                string answer = Console.ReadLine().Trim().ToUpper();

                if (answer == "Y")
                    return true;

                if (answer == "N")
                    return false;

                Console.WriteLine("Invalid input. Please enter Y or N only.");
            }
        }
    }
}