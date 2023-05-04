using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittens.Data.Entities;
using ExplosiveKittens.Data.Enums;
using ExplosiveKittens.Data.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExplosiveKittens.Business.Services
{
    internal class GamePlayerService: IGamePlayerService
    {
        private GamePlayerRepository _gamePlayerCacheRepo;
        public GamePlayerService(GamePlayerRepository repo)
        {
            _gamePlayerCacheRepo = repo;
        }

        public async Task<Guid?> GetGameByUserId(Guid userId)
        {
            Game game = _gamePlayerCacheRepo.GetBy(x => x.Players.Any(y => y.UserId.Equals(userId))).FirstOrDefault();
            return game?.Id;
        }

        public async Task<Game> Create(GameType)
    }
}
