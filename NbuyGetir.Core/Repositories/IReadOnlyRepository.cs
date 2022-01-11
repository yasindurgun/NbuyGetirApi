using NbuyGetir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity Find(string key);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> lambda);
        IQueryable<TEntity> List(); //order, include, take, skip gibi işlemler için IQuerable yaptık.
    }
}
