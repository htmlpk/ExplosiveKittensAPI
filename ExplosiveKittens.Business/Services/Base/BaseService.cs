using ExplosiveKittens.Business.Interfaces.Base;
using ExplosiveKittens.Data.Entities;
using Redis.OM;
using Redis.OM.Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveKittens.Business.Services
{
    public  abstract class BaseService<T>:IBaseService<T> where T : class
    {
        protected readonly RedisCollection<T> _repo;
        protected readonly RedisConnectionProvider _provider;
        public BaseService(RedisConnectionProvider provider)
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
