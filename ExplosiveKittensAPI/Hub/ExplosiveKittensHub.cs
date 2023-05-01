using Microsoft.AspNetCore.SignalR;

namespace ExplosiveKittensAPI.Hub
{
    public class ExplosiveKittensHub : Microsoft.AspNetCore.SignalR.Hub
    {

        public override Task OnConnectedAsync()
        {
            var a = Clients.All;
            return base.OnConnectedAsync();
        }
    }
}
