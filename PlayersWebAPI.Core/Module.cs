using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using PlayersWebAPI.Core.Entities;
using PlayersWebAPI.Core.Services;
using PlayersWebAPI.Core.Services.Abstractions;
using System.Reflection;

namespace PlayersWebAPI.Core
{
    public static class Module
    {
        public static void AddApiPlayersCore(this IServiceCollection services)
        {
            services
                .AddHelpers()
                .AddServices();
        }

        private static IServiceCollection AddHelpers(this IServiceCollection services)
        => services
                .AddSingleton<IFileProvider>(new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), "PlayersWebAPI.Core.Resources"))
                .AddSingleton<IResourceHelper<Player>>(sp => new ResourceHelper<Player>(sp.GetService<IFileProvider>(), "players.json"));
        

        private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddTransient<IPlayerService, PlayerService>();
    }
}
