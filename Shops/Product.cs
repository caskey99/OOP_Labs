using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Product
    {
        public string Name;
        public int pID;
        public double Price;
        public int Quantity;
        public double QuantityForPrice;
        public Product(string Name, int pID)
        {
            this.Name = Name;
            this.pID = pID;
        }
        public Product(Product Pr, int Quantity, double Price)
        {
            this.pID = Pr.pID;
            this.Name = Pr.Name;
            if(Quantity < 0)
                throw new Exception("Quantity < 0");
            if(Price < 0)
                throw new Exception("Price < 0");
            this.Quantity = Quantity;
            this.Price = Price;
        }
    }
}
