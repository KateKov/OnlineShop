using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class OrderViewModel
    {
        
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
        public decimal Summ { get; set; }
        
    }
    public class OrderModel {
        public static decimal Summ(ProductViewModel product, int count)
        {
            return product.Price * count;
        }

    }
}