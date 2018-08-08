using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.Common.Repository.Interface
{
    public interface IRepositoryUnclePhill<TDomain,TKey>
        where TDomain:class
    {
        List<TDomain> Select(Expression<Func<TDomain, bool>> where = null);

        TDomain SelectByKey(TKey Key);

        void Insert(TDomain Domain);

        void Update(TDomain Domain);

        void Delete(TDomain Domain);

        void DeleteByKey(TKey Key);
    }
}
