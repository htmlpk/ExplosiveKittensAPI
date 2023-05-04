using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittens.Data.Enums;
using ExplosiveKittens.VewModels;
using Microsoft.AspNetCore.SignalR;

namespace ExplosiveKittensAPI.Hub
{

    public interface ISomeHub
    {
        Task qse(CardViewModel data);
        Task SomeMethodB(object dss);
    }

    public class ExplosiveKittensHub : Hub<ISomeHub>
    {

        private readonly IGamePlayerService playerService;
        public ExplosiveKittensHub(IGamePlayerService playerService)
        {
            string a = "";
        }

        public override Task OnConnectedAsync()
        {
            var a = Context.ConnectionId;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
           await base.OnDisconnectedAsync(exception);
        }


        public async Task CreateGame(GameType type, Guid userId)
        {
            await playerService.CreateAsync(type, userId);
        }

        public async Task<Guid?> GetGameByUserId(Guid userId, GameType gameType)
        {
            return await playerService.GetGameByUserId(userId, gameType);
        }
        public void RestoreGamePlayerConnection(GameType gameType, Guid gameId, Guid userId, string connectionId)
        {
            playerService.RestoreGamePlayerConnection(gameType,gameId, userId, connectionId);
        }
        public void AddGamePlayer(GameType gameType, Guid gameId, Guid userId, string connectionId)
        {
            playerService.AddGamePlayer(gameType, gameId, userId, connectionId);
        }
        public void RemoveGamePlayer(GameType gameType, Guid gameId, Guid userId)
        {
            playerService.RemoveGamePlayer(gameType, gameId, userId);
        }
    }                      
 }