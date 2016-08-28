using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Interfaces
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }
}
