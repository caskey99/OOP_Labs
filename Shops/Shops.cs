using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Lab2
{
    public class Shop
    {
        public string Name, Address;
        int ID;
        private List<Product> ProductList;

        public Shop(string Name, string Address, int sID)
        {
            this.Name = Name;
            this.Address = Address;
            ID = sID;
            ProductList = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            foreach(var item in ProductList)
            {
                if (product.pID == item.pID)
                {
                    item.Quantity = product.Quantity;
                    item.Price = product.Price;
                    return ;
                }
            }
            ProductList.Add(product);
        }

        public double SearchСheaperProduct(Product Pr)
        {
            double MinPrice = int.MaxValue;
            var found = ProductList.Find(item => item.pID == Pr.pID);
            if (found != null)
                MinPrice = found.Price;
            return MinPrice;
        }

        public Dictionary<string, double> ProductForPrice(double Price)
        {
            int counter = 0;
            string Name;
            double CountPrice;
            Dictionary<string, double> ProductForPrice = new Dictionary<string, double>();
            while (counter < ProductList.Count)
            {
                CountPrice = Math.Truncate(Price / ProductList[counter].Price);
                Name = ProductList[counter].Name;
                ProductForPrice.Add(Name, CountPrice);
                counter++;
            }
            return ProductForPrice;
        }

        public double ProductParty(Dictionary<Product, int> ProductParty)
        {
            double SumProductParty = 0;
            foreach (KeyValuePair<Product, int> ProdQuantity in ProductParty)
            {
                foreach (var item in ProductList)
                {
                    if (item.pID == ProdQuantity.Key.pID)
                    {
                        if(ProdQuantity.Value <= item.Quantity)
                            SumProductParty += (item.Price * ProdQuantity.Value);
                        else
                            throw new Exception("The quantity per request exceeds the quantity in the store!");
                    }
                }
            }
            return SumProductParty;
        }
    }

}