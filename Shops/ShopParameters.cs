using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class ShopParameters
    {
        private List<Shop> ShopList = new List<Shop>();

        public void AddShop (Shop Sh)
        {
            ShopList.Add(Sh);
        }

        public Shop SearchСheaper(Product product)
        {
            double MinPrice = int.MaxValue;
            Shop ShopMinPrice = null;
            foreach (Shop item in ShopList)
            {
                if (MinPrice > item.SearchСheaperProduct(product))
                {
                    MinPrice = item.SearchСheaperProduct(product);
                    ShopMinPrice = item;
                }
            }
            return ShopMinPrice;
        }

        public Shop ProductPartyMinPrice(Dictionary<Product, int> ProductPartyMinPrice)
        {
            double SumProductParty;
            double MinSumProductParty = double.MaxValue;
            Shop ShopMinPrice = null;
            foreach (Shop Sitem in ShopList)
            {
                SumProductParty = Sitem.ProductParty(ProductPartyMinPrice);
                if (SumProductParty < MinSumProductParty)
                {
                    MinSumProductParty = SumProductParty;
                    ShopMinPrice = Sitem;
                }
                SumProductParty = 0;
            }
            return ShopMinPrice;
        }
    }
}
