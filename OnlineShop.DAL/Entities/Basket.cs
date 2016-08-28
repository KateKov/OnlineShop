using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Interfaces;

namespace OnlineShop.DAL.Entities
{
    public class Basket: IEntityBase
    {
        public Basket()
        {
            OrderProducts = new List<OrderProduct>();
        }
        [Key]
      
        public Guid Id { get; set; }
        [DisplayName("Сумма заказа")]
        public decimal Summ { get; set; }

        //Navigation property for OrderProduct.db
        [DisplayName("Товар")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        //Navigation property for Purchases.db
        [DisplayName("Заказ")]
        public virtual Purchase Purchase { get; set; }

    }
}
