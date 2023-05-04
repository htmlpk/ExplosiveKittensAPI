using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittens.Data.Entities;
using ExplosiveKittens.Data.Enums;
using ExplosiveKittens.VewModels;
using Microsoft.AspNetCore.SignalR;

namespace ExplosiveKittensAPI.Hub
{

    public interface ISomeHub
    {
        Task qse(CardViewModel data);
        Task SomeMethodB(object dss);
        Task Notify(Game game);
    }

    public class ExplosiveKittensHub : Hub<ISomeHub>
    {

        private readonly IGamePlayerService playerService;
        public ExplosiveKittensHub(
            IGamePlayerService playerService
            )
        {
            this.playerService = playerService;
        }

        public override async Task OnConnectedAsync()
        {
            var a = Context.ConnectionId;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
           await base.OnDisconnectedAsync(exception);
        }

        [HubMethodName("create-game")]
        public async Task<Game> CreateGame(GameType type, Guid userId)
        {
            var connectionId = Context.ConnectionId;
            var game = await playerService.CreateAsync(type, userId, connectionId);
            await Clients.AllExcept(connectionId).Notify(game);
            return game;
        }

        [HubMethodName("get-game-by-user-id")]
        public async Task<Guid?> GetGameByUserId(Guid userId, GameType gameType)
        {
            return await playerService.GetGameByUserId(userId, gameType);
        }

        [HubMethodName("restore-game-player-connection")]
        public async Task RestoreGamePlayerConnection(GameType gameType, Guid gameId, Guid userId)
        {
            var connectionId = Context.ConnectionId;
            await playerService.RestoreGamePlayerConnection(gameType, gameId, userId, connectionId);
        }

        [HubMethodName("add-game-player")]
        public async Task AddGamePlayer(GameType gameType, Guid gameId, Guid userId)
        {
            var connectionId = Context.ConnectionId;
            await playerService.AddGamePlayer(gameType, gameId, userId, connectionId);
        }

        [HubMethodName("remove-game-player")]
        public async Task RemoveGamePlayer(GameType gameType, Guid gameId, Guid userId)
        {
            await playerService.RemoveGamePlayer(gameType, gameId, userId);
        }
    }                      
 }