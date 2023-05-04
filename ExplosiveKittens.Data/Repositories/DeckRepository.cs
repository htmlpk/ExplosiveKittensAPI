using ExplosiveKittens.Data.Entities;
using ExplosiveKittens.Data.Interfaces;
using Redis.OM;

namespace ExplosiveKittens.Data.Repositories
{
    public class DeckRepository: BaseRepository<Deck>,IDeckRepository
    {
        public DeckRepository(RedisConnectionProvider provider)
            :base(provider)
        {
        }
    }
}
