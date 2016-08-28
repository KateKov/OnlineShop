using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OnlineShop.DAL.Interfaces;

namespace OnlineShop.DAL.Entities
{
    public class Color: IEntityBase
    {
        public Color()
        {
            Products = new List<Product>();
        }
        
        public Guid Id { get; set; }
        [DisplayName("Название"), MaxLength(30, ErrorMessage = "Название не может состоять более чем из 30 символов")]
        public string Name { get; set; }
        [DisplayName("Изображение")]
        public string CssColor { get; set; }
        //Navigation property for Products.db
        [DisplayName("Товары")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
