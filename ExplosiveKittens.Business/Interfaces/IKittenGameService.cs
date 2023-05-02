using ExplosiveKittens.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExplosiveKittens.Business.Interfaces
{
    public interface IKittenGameService
    {
        Task CreateDeckInCacheAsync();
        Task<IList<Deck>> GetDeckAsync(Guid gameId);
    }
}
