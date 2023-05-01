using ExplosiveKittens.Data.Entities;
using Redis.OM;
using System.Threading;
using System.Threading.Tasks;

namespace ExplosiveKittens.Business.HostedServices
{
    public class IndexCreationService : Microsoft.Extensions.Hosting.IHostedService
    {
        private readonly RedisConnectionProvider _provider;
        public IndexCreationService(RedisConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _provider.Connection.CreateIndexAsync(typeof(Deck));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
