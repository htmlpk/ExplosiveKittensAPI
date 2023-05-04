using ExplosiveKittens.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExplosiveKittens.Data.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetByAsync(Func<T, bool> predicate);
        Task<string> CreateAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
