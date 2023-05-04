using ExplosiveKittens.Data.Entities.Base;
using ExplosiveKittens.Data.Interfaces.Base;
using Redis.OM;
using Redis.OM.Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public virtual async Task<IList<T>> GetByAsync(Func<T,bool> predicate)
        {
            return await Task.FromResult(_repo.Where(predicate).ToList());
        }

        public virtual async Task<string> CreateAsync(T entity)
        {
            return await _repo.InsertAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _repo.UpdateAsync(entity);
        }
    }
}
