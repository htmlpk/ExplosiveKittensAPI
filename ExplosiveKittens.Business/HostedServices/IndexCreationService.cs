﻿using ExplosiveKittens.Data.Entities;
using Microsoft.Extensions.Hosting;
using Redis.OM;
using System.Threading;
using System.Threading.Tasks;

namespace ExplosiveKittens.Business.HostedServices
{
    public class IndexCreationService : IHostedService
    {
        private readonly RedisConnectionProvider _provider;
        public IndexCreationService(RedisConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _provider.Connection.CreateIndexAsync(typeof(Deck));
            await _provider.Connection.CreateIndexAsync(typeof(Game));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
