using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittens.VewModels;
using ExplosiveKittensAPI.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ExplosiveKittensAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExplosiveKittensGameController : ControllerBase
    {

        private readonly IHubContext<ExplosiveKittensHub, ISomeHub> _hub;
        private readonly IKittensGameService _gameService;

        public ExplosiveKittensGameController(IHubContext<ExplosiveKittensHub, ISomeHub> hub, IKittensGameService gameService)
        {
            _hub = hub;
            _gameService = gameService;
        }


        [HttpGet]
        [Route("createDeck")]
        public async Task<IActionResult> Test()
        {
            await _gameService.CreateDeckInCacheAsync();
            return Ok(new { Message = "Test Request Completed" });
        }

        [HttpGet]
        [Route("getDeck/{gameId}")]
        public async Task<IActionResult> Test2(Guid gameId)
        {
            return Ok(await _gameService.GetDeckAsync(gameId));
        }


        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Test3()
        {
            var model = new CardViewModel();
            await _hub.Clients.All.SomeMethodB(model);

            await _hub.Clients.All.qse(model);

            //await _hub.Clients.All.SendAsync("qwe", model);
            return Ok(new { Message = "Test Request Completed" });
        }

        [HttpGet]
        [Route("test2/{connectionId}")]
        public async Task<IActionResult> Test2(string connectionId)
        {
            var model = new CardViewModel();

            await _hub.Clients.Client(connectionId).qse(model);

            //await _hub.Clients.All.SendAsync("qwe", model);
            return Ok(new { Message = "Test Request Completed" });
        }


    }
}