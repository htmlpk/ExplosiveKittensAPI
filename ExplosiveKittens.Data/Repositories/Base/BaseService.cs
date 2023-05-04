using ExplosiveKittens.Data.Entities.Base;
using ExplosiveKittens.Data.Interfaces.Base;
using Redis.OM;
using Redis.OM.Searching;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplosiveKittens.Data.Repositories
{
    public  abstract class BaseRepository<T>:IBaseRepository<T> where T : BaseEntity
    {
        protected readonly RedisCollection<T> _repo;
        protected readonly RedisConnectionProvider _provider;
        public BaseRepository(RedisConnectionProvider provider)
        {
            _provider = provider;
            _repo = (RedisCollection<T>)provider.RedisCollection<T>();
        }

        public virtual  IList<T> GetBy(Func<T,bool> predicate)
        {
            return _repo.Where(predicate).ToList();
        }
    }
}
