using BattleshipGame.Application;
using BattleshipGame.Domain.Interfaces;
using BattleshipGame.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleshipGame.UI.Console
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Register domain services with their interfaces.
            services.AddSingleton<IShipService, ShipService>();
            services.AddSingleton<IShotService, ShotService>();
            services.AddSingleton<IBoardService, BoardService>();

            // Register the Game class.
            services.AddSingleton<Game>();
        }
    }
}
