using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittens.Data.Entities;
using Redis.OM;

namespace ExplosiveKittens.Business.Services
{
    public class GamePlayerService: BaseService<GamePlayer>,IGamePlayerService<GamePlayer>
    {
        public GamePlayerService(RedisConnectionProvider provider)
            :base(provider)
        {
        }

        public void qwe()
        {
        }
    }
}
