using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittens.Business.Services;
using ExplosiveKittens.Data.Interfaces;
using ExplosiveKittens.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExplosiveKittens.Business
{
    public static class Startup
    {
        public static void ConfigureRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDeckRepository,DeckRepository>();
            serviceCollection.AddScoped<IGamePlayerRepository, GamePlayerRepository>();
        }

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddScoped<IGamePlayerService, GamePlayerService>();
            serviceCollection.AddScoped<IKittensGameService, KittensGameService>();
        }


    }
}
