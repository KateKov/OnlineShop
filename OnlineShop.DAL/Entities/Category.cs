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
    //The categoty of goods (clothing, accessories)
    public class Category: IEntityBase
    {
        public Category()
        {
            Subcategories = new List<Subcategory>();
        }
        [Key]
        
        public Guid Id { get; set; }
        [DisplayName("Название"), MaxLength(30, ErrorMessage = "Название не может состоять более чем из 30 символов")]
        public string Title { get; set; }

        //Navigation property for Catalogs.db
       
        [ForeignKey("Catalog")]
        public Guid CatalogId { get; set; }
        [DisplayName("Каталог")]
        public virtual Catalog Catalog { get; set; }
        //Navigation property for Subcategories.db
        [DisplayName("Подкатегории")]
        public virtual ICollection<Subcategory> Subcategories { get; set; }

       
        

    }
}
