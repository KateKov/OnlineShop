using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.EF;



namespace OnlineShop.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
