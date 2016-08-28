using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OnlineShop.DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.DAL.Entities
{
    public class Purchase: IEntityBase
    {
        [Key]
        [ForeignKey("Basket")]
       
        public Guid Id { get; set; }
        [DisplayName("Статус заказа"), Required, MaxLength(30, ErrorMessage = "Статус не может состоять более чем из 30 символов")]
        public string Status { get; set; }

        //Navigation property for Baskets.db
        [DisplayName("Корзина")]
        public virtual Basket Basket { get; set; }

        [DisplayName("Дата заказа"), DataType(DataType.Date), Required]
        public DateTime DateOfPurchase { get; set; }
        
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        [DisplayName("Покупатель")]
        public virtual Customer Customer { get; set; }
    }
}
