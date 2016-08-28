using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineShop.DAL.Entities
{
    public class Subcategory
    {
        public Subcategory()
        {           
            Products = new List<Product>();
        }
        //Navigation property for Products.db
        [DisplayName("Товары")]
        public virtual ICollection<Product> Products { get; set; }
        [Key]
        
        public Guid Id { get; set; }
        [DisplayName("Название"), Required, MaxLength(30, ErrorMessage = "Название не может состоять более чем из 30 символов")]
        public string Title { get; set; }
        //Navigation property for Categories.db
        
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        [DisplayName("Каталог")]
        public virtual Category Category { get; set; }
    }
}
