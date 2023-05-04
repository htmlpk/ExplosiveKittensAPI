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

        //public async Task<string> Create()
        //{
        //    var gameid = Guid.NewGuid().ToString();
        //    Game newGame = new Game() { }
        //    await _repo.InsertAsync(x => x.GameId == gameId);
        //}
    }
}
