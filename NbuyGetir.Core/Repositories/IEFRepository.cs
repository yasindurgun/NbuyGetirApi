using NbuyGetir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Repositories
{
    // ISP => Interface Seggregation
    //EF yi hem read hem write işlemleri için kullanacağız.
    public interface IEFRepository<TEntity> : IReadOnlyRepository<TEntity>, IWriteOnlyRepository<TEntity> where TEntity: IAggregateRoot
    {
    }
}
