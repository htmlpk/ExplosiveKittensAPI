using ExplosiveKittens.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace ExplosiveKittens.Data.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IList<T> GetBy(Func<T, bool> predicate);
    }
}
