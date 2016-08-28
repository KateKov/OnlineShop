using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Interfaces;

namespace OnlineShop.DAL.Entities
{
    public class Size: IEntityBase
    {
        public Size()
        {
            Products = new List<Product>();
        }
        public Guid Id { get; set; }
        public int Number { get; set; }
        //Navigation properties for Products.db
        public virtual List<Product> Products { get; set; }
    }
}
