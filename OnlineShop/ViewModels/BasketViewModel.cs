using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class BasketViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public decimal Summ { get
            {
                decimal summ = 0;
                Orders.ForEach(x => summ += x.Summ);
                return summ;} }

    }
}