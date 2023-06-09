﻿using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittens.Data.Entities;
using ExplosiveKittens.Data.Enums;
using ExplosiveKittens.Data.Interfaces;
using ExplosiveKittens.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplosiveKittens.Business.Services
{
    public class GamePlayerService: IGamePlayerService
    {
        private IGamePlayerRepository _gamePlayerCacheRepo;
        public GamePlayerService(IGamePlayerRepository repo)
        {
            _gamePlayerCacheRepo = repo;
        }

        public async Task<Guid?> GetGameByUserId(Guid userId,GameType gameType)
        {
            Game game = (await _gamePlayerCacheRepo.GetByAsync(x =>x.GameType.Equals(gameType) && x.Players.Any(y => y.UserId.Equals(userId)))).FirstOrDefault();
            return game?.Id;
        }

        public async Task<Game> CreateAsync(GameType type, Guid userId, string connectionId)
        {
            var game = new Game() { Id = Guid.NewGuid(), Players = new List<Player>() { new Player() { Id = userId, Order = 1, ConnectionId = connectionId } } };
            await _gamePlayerCacheRepo.CreateAsync(game);
            return game;
        }

        public async Task RestoreGamePlayerConnection(GameType gameType,Guid gameId,Guid userId,string connectionId)
        {
            Game game = (await _gamePlayerCacheRepo.GetByAsync(x => x.Id.Equals(gameId))).FirstOrDefault();
            if(game == null)
            {
                throw new Exception("Game is not found");
            }
            Player player = game.Players.Where(x=>x.UserId.Equals(userId)).FirstOrDefault();
            player.ConnectionId = connectionId;
            await _gamePlayerCacheRepo.UpdateAsync(game);
        }

        public async Task AddGamePlayer(GameType gameType, Guid gameId, Guid userId, string connectionId)
        {
            Game game = (await _gamePlayerCacheRepo.GetByAsync(x => x.Id.Equals(gameId))).FirstOrDefault(); 
            if (game == null)
            {
                throw new Exception("Game is not found");
            }
            Player player = new Player() { ConnectionId = connectionId, UserId = userId, Order = game.Players.Count - 1 };
            game.Players.Add(player);
            await _gamePlayerCacheRepo.UpdateAsync(game);
        }

        public async Task RemoveGamePlayer(GameType gameType, Guid gameId, Guid userId)
        {
            Game game = (await _gamePlayerCacheRepo.GetByAsync(x => x.Id.Equals(gameId))).FirstOrDefault();
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

        public async Task<List<string>> GetGamePlayersConnectionIds(GameType gameType, Guid gameId)
        {
            Game game = (await _gamePlayerCacheRepo.GetByAsync(x => x.Id.Equals(gameId))).FirstOrDefault();
            if (game == null)
            {
                throw new Exception("Game is not found");
            }
            return await Task.FromResult(game.Players.Select(x => x.ConnectionId).ToList());
        }

    }
}
