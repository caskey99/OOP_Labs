using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // | 1 |                  
            Shop Magnet = new Shop("Magnet", "Spassky lane, 14/35", 0); //"0"
            Shop Pyaterochka = new Shop("Pyaterochka", "Manezhnaya square, 6", 1); //"1"
            Shop Okay = new Shop("Okay", "Marshal Zhukov, 31", 2); //"2"
            ShopParameters SpMaster = new ShopParameters();
            SpMaster.AddShop(Magnet);
            SpMaster.AddShop(Pyaterochka);
            SpMaster.AddShop(Okay);

            // | 2 |
            Product Milk = new Product("Milk", 0); //"0"
            Product Bread = new Product("Bread", 1); //"1"
            Product Meat = new Product("Meat", 2); //"2"
            Product Apple = new Product("Apple", 3); //"3"
            Product Chocolate = new Product("Chocolate", 4); //"4"
            Product Cake = new Product("Cake", 5); //"5"
            Product Sausage = new Product("Sausage", 6); //"6"
            Product Ketchup = new Product("Ketchup", 7); //"7"
            Product CocaCola = new Product("CocaCola", 8); //"8"
            Product Chips = new Product("Chips", 9); //"9"
            Product Yogurt = new Product("Yogurt", 10); //"10"

            // | 3 | 
            // Push Magnet
            Magnet.AddProduct(new Product (Milk, 20, 55));
            Magnet.AddProduct(new Product (Bread, 50, 45));
            Magnet.AddProduct(new Product(Apple, 200, 10));
            Magnet.AddProduct(new Product(Meat, 30, 150));
            Magnet.AddProduct(new Product(Chocolate, 30, 150));
            Magnet.AddProduct(new Product(Cake, 20, 300));
            Magnet.AddProduct(new Product(Sausage, 55, 100));
            Magnet.AddProduct(new Product(Ketchup, 60, 80));
            Magnet.AddProduct(new Product(CocaCola, 35, 70));
            Magnet.AddProduct(new Product(Chips, 60, 90));
            Magnet.AddProduct(new Product(Yogurt, 35, 30));


            //  Push in Pyatrtochka
            Pyaterochka.AddProduct(new Product(Milk, 25, 50));
            Pyaterochka.AddProduct(new Product(Bread, 50, 50));
            Pyaterochka.AddProduct(new Product(Bread, 100, 45));
            Pyaterochka.AddProduct(new Product(Apple, 100, 15));
            Pyaterochka.AddProduct(new Product(Chocolate, 40, 120));
            Pyaterochka.AddProduct(new Product(Meat, 50, 140));
            Pyaterochka.AddProduct(new Product(Cake, 30, 290));
            Pyaterochka.AddProduct(new Product(Sausage, 60, 120));
            Pyaterochka.AddProduct(new Product(Ketchup, 50, 75));
            Pyaterochka.AddProduct(new Product(CocaCola, 40, 75));
            Pyaterochka.AddProduct(new Product(Chips, 45, 100));
            Pyaterochka.AddProduct(new Product(Yogurt, 35, 30));


            // Push in Okay
            Okay.AddProduct(new Product(Milk, 200, 49));
            Okay.AddProduct(new Product(Bread, 250, 49));
            Okay.AddProduct(new Product(Apple, 600, 20));
            Okay.AddProduct(new Product(Chocolate, 100, 80));
            Okay.AddProduct(new Product(Meat, 200, 130));
            Okay.AddProduct(new Product(Cake, 50, 280));
            Okay.AddProduct(new Product(Sausage, 200, 115));
            Okay.AddProduct(new Product(Ketchup, 300, 80));
            Okay.AddProduct(new Product(CocaCola, 170, 65));
            Okay.AddProduct(new Product(Chips, 120, 95));
            Okay.AddProduct(new Product(Yogurt, 80, 25));

            // | 4 |

            Console.WriteLine("Task 4");
            Console.WriteLine(SpMaster.SearchСheaper(Milk).Name);
            Console.WriteLine("");

            // | 5 |
            Console.WriteLine("Task 5");
            var answer1 = Pyaterochka.ProductForPrice(1000);
            foreach (var item in answer1)
                Console.WriteLine(item);

            //Okay.ProductForPrice(100);
            //Magnet.ProductForPrice(100);
            Console.WriteLine("");

            // | 6 |
            Console.WriteLine("Task 6");
            Dictionary<Product, int> ProductParty = new Dictionary<Product, int>();
            ProductParty.Add(Milk, 2);
            ProductParty.Add(Bread, 99);
            ProductParty.Add(Apple, 3);
            if ((Pyaterochka.ProductParty(ProductParty)) == 0)
                Console.WriteLine("These products are not available in the store!");
            else
                Console.WriteLine(Pyaterochka.ProductParty(ProductParty));
            Console.WriteLine("");

            // | 7 |
            Console.WriteLine("Task 7");
            Dictionary<Product, int> ProductPartyMinPrice = new Dictionary<Product, int>();
            ProductPartyMinPrice.Add(Milk, 2);
            ProductPartyMinPrice.Add(Bread, 2);
            ProductPartyMinPrice.Add(Apple, 3);
            var answer2 = SpMaster.ProductPartyMinPrice(ProductPartyMinPrice);
            Console.WriteLine(answer2.Name);
            Console.WriteLine("");
        }

    }
}
