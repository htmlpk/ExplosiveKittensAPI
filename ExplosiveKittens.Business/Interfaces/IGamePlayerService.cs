using ExplosiveKittens.Data.Entities;
using ExplosiveKittens.Data.Enums;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ExplosiveKittens.Business.Interfaces
{
    public interface IGamePlayerService
    {

        Task<Game> CreateAsync(GameType type, Guid userId, string connectionId);
        Task<Guid?> GetGameByUserId(Guid userId, GameType gameType);
        Task RestoreGamePlayerConnection(GameType gameType, Guid gameId, Guid userId, string connectionId);
        Task AddGamePlayer(GameType gameType, Guid gameId, Guid userId, string connectionId);
        Task RemoveGamePlayer(GameType gameType, Guid gameId, Guid userId);
        Task<List<string>> GetGamePlayersConnectionIds(GameType gameType, Guid gameId);
    }
}
