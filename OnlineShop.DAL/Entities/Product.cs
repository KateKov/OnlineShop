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
    public class Product: IEntityBase
    {
        public Product()
        {
            Images = new List<Image>();
            Sizes = new List<Size>();
            OrderProduct = new List<OrderProduct>();
        }
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [DisplayName("Название"), Required, MaxLength(30, ErrorMessage = "Название не может состоять более чем из 30 символов")]
        public string Title { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        //Navigation properties for Subategories.db
        
        [ForeignKey("Subcategory")]
        public Guid SubcategoryId { get; set; }
        [DisplayName("Подкатегория")]
        public virtual Subcategory Subcategory { get; set; }

        //Navigation property for Colors.db
       
        [ForeignKey("Color")]
        public Guid ColorId { get; set; }
        [DisplayName("Цвет")]
        public virtual Color Color { get; set; }

        //Navigation property for Images.db
        [DisplayName("Изображения")]
        public virtual ICollection<Image> Images { get; set; }

        [DisplayName("Описание"), DataType(DataType.MultilineText), MaxLength(4000, ErrorMessage = "Описание не может состоять более чем из 4000 символов")]
        public string Description { get; set; }
        [DisplayName("Состав"), MaxLength(400, ErrorMessage = "Состав не может состоять более чем из 400 символов")]
        public string Materials { get; set; }
        [DisplayName("Дата добавления")]
        public DateTime DateOfAddition { get; set; }
        [DisplayName("Популярность")]
        public double Popularity { get; set; }
        [DisplayName("Скидка")]
        public int Discount { get; set; }
        [DisplayName("Количество")]
        public int Amount { get; set; }

        //Navigation properties for Sizes.db
        [DisplayName("Размеры")]
        public virtual List<Size> Sizes { get; set; }

        //Navigation properties for Collections.db
        [HiddenInput(DisplayValue = false)]
        public Guid? CollectionId { get; set; }
        [DisplayName("Коллекция")]
        public virtual Collection Collection { get; set; }

        //Navigation properties for OrderProducts.db
        [DisplayName("Заказ")]
        public virtual List<OrderProduct> OrderProduct { get; set; }



    }
}
