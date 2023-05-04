using ExplosiveKittens.Data.Entities;
using ExplosiveKittens.Data.Enums;
using System.Threading.Tasks;
using System;

namespace ExplosiveKittens.Business.Interfaces
{
    public interface IGamePlayerService
    {

        Task<Game> CreateAsync(GameType type, Guid userId);
        Task<Guid?> GetGameByUserId(Guid userId, GameType gameType);
        void RestoreGamePlayerConnection(GameType gameType, Guid gameId, Guid userId, string connectionId);
        void AddGamePlayer(GameType gameType, Guid gameId, Guid userId, string connectionId);
        void RemoveGamePlayer(GameType gameType, Guid gameId, Guid userId);

    }
}
