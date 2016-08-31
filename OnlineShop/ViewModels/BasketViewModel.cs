using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class BasketViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public decimal Summ { get; set; }

    }
    public class BasketModel
    {
        public static decimal Summ(List<OrderViewModel> orders)
        {
            decimal summ = 0;
            orders.ForEach(x => summ += x.Summ);
            return summ;
        }
    }
}