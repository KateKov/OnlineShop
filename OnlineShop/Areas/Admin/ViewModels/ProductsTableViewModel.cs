using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.ViewModels
{
    public class ProductsTableViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите название"), MaxLength(30, ErrorMessage = "Название не может состоять более чем из 30 символов")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Введите цену")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Выберите категорию")]
        public Guid CategoryId { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage = "Выберите каталог")]
        public Guid CatalogId { get; set; }
        public string Catalog { get; set; }

        [Required(ErrorMessage = "Введите подкатегорию")]
        public Guid SubcategoryId { get; set; }
        public string Subcategory { get; set; }
        [Required(ErrorMessage = "Введите размер")]
        public string Sizes { get; set; }
        [Required(ErrorMessage = "Введите цвет")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [DataType(DataType.MultilineText), MaxLength(4000, ErrorMessage = "Описание не может состоять более чем из 4000 символов")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите состав")]
        [MaxLength(400, ErrorMessage = "Состав не может состоять более чем из 400 символов")]
        public string Materials { get; set; }
        [Required(ErrorMessage = "Введите популярность")]
        [Range(0, 5, ErrorMessage = "Популярость должна быть от 0 до 5")]
        public double Popularity { get; set; }
        [Required(ErrorMessage = "Введите скидку")]
        public int Discount { get; set; }
        [Required(ErrorMessage = "Введите количество")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Введите коллекцию")]
        public Guid CollectionId { get; set; }
        public string Collection { get; set; }
        [Required(ErrorMessage = "Введите бренд")]
        public Guid BrandId { get; set; }
        public string Brand { get; set; }
    }
}