using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.DAL.Entities
{
    public class Error : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
