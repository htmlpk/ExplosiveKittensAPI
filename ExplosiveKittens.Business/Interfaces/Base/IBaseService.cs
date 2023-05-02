using System;
using System.Collections.Generic;

namespace ExplosiveKittens.Business.Interfaces.Base
{
    public interface IBaseService<T>
    {
        IList<T> GetBy(Func<T, bool> predicate);
    }
}
