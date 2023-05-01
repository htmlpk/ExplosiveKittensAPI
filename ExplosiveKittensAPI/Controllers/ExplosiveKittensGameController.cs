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

        private readonly IHubContext<ExplosiveKittensHub> _hub;

        public ExplosiveKittensGameController(IHubContext<ExplosiveKittensHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Test()
        {
            var model = new CardViewModel();
            await _hub.Clients.All.SendAsync("transfer", model);
            return Ok(new { Message = "Test Request Completed" });
        }


    }
}