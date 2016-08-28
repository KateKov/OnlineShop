using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OnlineShop.DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.DAL.Entities
{
    public class OrderProduct: IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        //Navigation property for Products.db
        [DisplayName("Товар")]
        public virtual Product Product { get; set; }
    }
}
