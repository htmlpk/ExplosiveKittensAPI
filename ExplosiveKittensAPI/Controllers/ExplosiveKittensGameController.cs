using ExplosiveKittens.VewModels;
using ExplosiveKittensAPI.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.Xml;

namespace ExplosiveKittensAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExplosiveKittensGameController : ControllerBase
    {

        private readonly IHubContext<ExplosiveKittensHub, ISomeHub> _hub;

        public ExplosiveKittensGameController(IHubContext<ExplosiveKittensHub, ISomeHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Test()
        {
            var model = new CardViewModel();
            await _hub.Clients.All.SomeMethodB(model);

            var g2 = new Card();
            await _hub.Clients.All.BroadcastChartData(g2);

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