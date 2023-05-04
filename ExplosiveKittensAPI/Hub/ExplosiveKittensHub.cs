using ExplosiveKittens.VewModels;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ExplosiveKittensAPI.Hub
{

    public interface ISomeHub
    {

        Task qse(CardViewModel data);
        Task SomeMethodB(object dss);

        Task BroadcastChartData(Card data);
    }

    public class ExplosiveKittensHub : Hub<ISomeHub>
    {
        public ExplosiveKittensHub()
        {
            string a = "";
        }

        public override Task OnConnectedAsync()
        {
            var a = Context.ConnectionId;
            return base.OnDisconnectedAsync(null);

            return base.OnConnectedAsync();
        }

        public Task qwerty(CardViewModel data)
        {
            return Clients.All.qse(data);
        }


        [HubMethodName("SendMessageToUser")]
        public Task SomeMethodB(Card data)
        {
            return Clients.All.SomeMethodB(data);
        }

        public Task BroadcastChartData(Card data)
        {
            var a = data;
            return Clients.All.BroadcastChartData(a);
            //return Clients.All.SendAsync("broadcastchartdata", data);
        }
    }

 }

public class Card
{
    public string Name { get; set; }
}
