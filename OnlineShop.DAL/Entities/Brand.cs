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
    public class Brand: IEntityBase
    {
        public Brand()
        {
            Collection = new List<Collection>();
        }
        [Key]
        
        public Guid Id { get; set; }
        [DisplayName("Статус заказа"), MaxLength(30, ErrorMessage = "Название не может быть длинее 30 символов")]
        public string Name { get; set; }
        [DisplayName("Описание"), DataType(DataType.MultilineText), MaxLength(400, ErrorMessage = "Описание не может состоять более длинее 400 символов")]
        public string Description { get; set; }

        //Navigation property for Collections.db
        [DisplayName("Коллекции")]
        public virtual ICollection<Collection> Collection { get; set; }
    }
}
