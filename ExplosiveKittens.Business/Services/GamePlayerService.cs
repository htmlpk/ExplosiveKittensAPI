using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittens.Data.Entities;
using ExplosiveKittens.Data.Enums;
using ExplosiveKittens.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplosiveKittens.Business.Services
{
    public class GamePlayerService: IGamePlayerService
    {
        private GamePlayerRepository _gamePlayerCacheRepo;
        public GamePlayerService(GamePlayerRepository repo)
        {
            _gamePlayerCacheRepo = repo;
        }

        public async Task<Guid?> GetGameByUserId(Guid userId,GameType gameType)
        {
            Game game = _gamePlayerCacheRepo.GetBy(x =>x.GameType.Equals(gameType) && x.Players.Any(y => y.UserId.Equals(userId))).FirstOrDefault();
            return game?.Id;
        }

        public async Task<Game> CreateAsync(GameType type, Guid userId)
        {
            var game = new Game() { Id = Guid.NewGuid(), Players = new List<Player>() { new Player() { Id = userId, Order = 1 } } };
            await _gamePlayerCacheRepo.CreateAsync(game);
            return game;
        }

        public async void RestoreGamePlayerConnection(GameType gameType,Guid gameId,Guid userId,string connectionId)
        {
            Game game = _gamePlayerCacheRepo.GetBy(x => x.Id.Equals(gameId)).FirstOrDefault();
            if(game == null)
            {
                throw new Exception("Game is not found");
            }
            Player player = game.Players.Where(x=>x.UserId.Equals(userId)).FirstOrDefault();
            player.ConnectionId = connectionId;
            await _gamePlayerCacheRepo.UpdateAsync(game);
        }

        public async void AddGamePlayer(GameType gameType, Guid gameId, Guid userId, string connectionId)
        {
            Game game = _gamePlayerCacheRepo.GetBy(x => x.Id.Equals(gameId)).FirstOrDefault(); 
            if (game == null)
            {
                throw new Exception("Game is not found");
            }
            Player player = new Player() { ConnectionId = connectionId, UserId = userId, Order = game.Players.Count - 1 };
            game.Players.Add(player);
            await _gamePlayerCacheRepo.UpdateAsync(game);
        }

        public void RemoveGamePlayer(GameType gameType, Guid gameId, Guid userId)
        {
            Game game = _gamePlayerCacheRepo.GetBy(x => x.Id.Equals(gameId)).FirstOrDefault();
            if (game == null)
            {
                throw new Exception("Game is not found");
            }
            var player = game.Players.Where(x=>x.UserId.Equals(userId)).FirstOrDefault();
            game.Players.Remove(player);
            for (int i = 0; i < game.Players.Count; i++)
            {
                game.Players[i].Order = i - 1;
            }
        }

        public List<string> GetGamePlayersConnectionIds(GameType gameType, Guid gameId)
        {
            Game game = _gamePlayerCacheRepo.GetBy(x => x.Id.Equals(gameId)).FirstOrDefault();
            if (game == null)
            {
                throw new Exception("Game is not found");
            }
            return game.Players.Select(x => x.ConnectionId).ToList();
        }

    }
}
