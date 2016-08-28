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
    public class Image: IEntityBase
    {
        [Key]
        
        public Guid Id { get; set; }
        [DisplayName("Изображение")]
        public string ImagePath { get; set; }
        //Navigation property for Products.db
        
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [DisplayName("Товар")]
        public virtual Product Product { get; set; }
    }
}
