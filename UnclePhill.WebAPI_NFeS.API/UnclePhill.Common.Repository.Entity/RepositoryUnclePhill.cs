using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnclePhill.Common.Repository.Interface;

namespace UnclePhill.Common.Repository.Entity
{
    public abstract class RepositoryUnclePhill<TDomain, TKey> : IRepositoryUnclePhill<TDomain, TKey>
        where TDomain:class
    {
        protected DbContext _context;

        public RepositoryUnclePhill(DbContext context)
        {
            _context = context;
        }

        public void Insert(TDomain Domain)
        {
            _context.Set<TDomain>().Add(Domain);
            _context.SaveChanges();
        }

        public void Update(TDomain Domain)
        {
            _context.Entry(Domain).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<TDomain> Select(Expression<Func<TDomain, bool>> where = null)
        {
            DbSet<TDomain> dbSet = _context.Set<TDomain>();
            if (where == null)
            {
                return dbSet.ToList();
            }
            else
            {
                return dbSet.Where(where).ToList();
            }
        }

        public TDomain SelectByKey(TKey Key)
        {
            return _context.Set<TDomain>().Find(Key);
        }

        public void Delete(TDomain Domain)
        {
            _context.Entry(Domain).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteByKey(TKey Key)
        {
            Delete(SelectByKey(Key));
        }   
    }
}
