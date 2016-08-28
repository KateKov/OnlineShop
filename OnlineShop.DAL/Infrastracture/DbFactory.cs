using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Interfaces;
using OnlineShop.DAL.EF;

namespace OnlineShop.DAL.Infrastracture
{
    public class DbFactory : Disposable, IDbFactory
    {
        OnlineShopContext dbContext;
        public OnlineShopContext Init()
        {
            return dbContext ?? (dbContext = new OnlineShopContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
