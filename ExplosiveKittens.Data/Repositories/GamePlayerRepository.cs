using ExplosiveKittens.Data.Entities;
using ExplosiveKittens.Data.Interfaces;
using Redis.OM;
using System;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace ExplosiveKittens.Data.Repositories
{
    public class GamePlayerRepository : BaseRepository<Game>,IGamePlayerRepository
    {
        public GamePlayerRepository(RedisConnectionProvider provider)
            :base(provider)
        {

        }
    }
}
