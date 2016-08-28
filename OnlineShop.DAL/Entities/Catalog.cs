using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Interfaces;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineShop.DAL.Entities
{
    public class Catalog: IEntityBase
    {
        public Catalog()
        {
            Categories = new List<Category>();
        }
        [Key]
       
        public Guid Id { get; set; }
        [DisplayName("Название"), MaxLength(30, ErrorMessage = "Название не может состоять более чем из 30 символов")]
        public string Title { get; set; }
        //Navigation property for Categories.db
        public virtual List<Category> Categories { get; set; }

    }
}
