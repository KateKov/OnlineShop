using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Interfaces;
using OnlineShop.DAL.EF;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace OnlineShop.DAL.Infrastracture
{
    public class Repository<T>: IRepository<T> where T: class, IEntityBase, new()
    {
        private OnlineShopContext db;
        public virtual IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }
        public Repository(OnlineShopContext context)
        {
            this.db = context;
        }
        public T Get(Guid id)
        {
            return db.Set<T>().Find(id);

        }
        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }
        public virtual void Create(T entity)
        {

            db.Set<T>().Add(entity);
            db.SaveChanges();
        }
        public virtual void Update(T entity)
        {
          
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();

        }
        public virtual void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
            
        }



    }
}
