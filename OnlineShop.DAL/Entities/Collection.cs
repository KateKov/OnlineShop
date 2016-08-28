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
    public class Collection: IEntityBase
    {
        public Collection()
        {
            Products = new List<Product>();
        }
        [Key]
        
        public Guid Id { get; set; }
        [DisplayName("Название"), MaxLength(30, ErrorMessage = "Название не может состоять более чем из 30 символов")]
        public string Name { get; set; }
        [DisplayName("Описание"), DataType(DataType.MultilineText), MaxLength(400, ErrorMessage = "Описание не может состоять более чем из 400 символов")]
        public string Description { get; set; }

        //Navigation properties for Brand.db
       
        [ForeignKey("Brand")]
        public Guid? BrandId { get; set; }
        [DisplayName("Бренд")]
        public virtual Brand Brand { get; set; }

        //Navigation property for Products.db
        [DisplayName("Товары")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
