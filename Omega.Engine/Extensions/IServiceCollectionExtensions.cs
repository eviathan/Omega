using Microsoft.Extensions.DependencyInjection;
using Omega.Core.Interfaces;
using Omega.Engine.Managers;
using Omega.Renderer.Text;

namespace Omega.Engine.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddOmegaEngine(this IServiceCollection services)
        {
            services.AddSingleton<OmegaEngine>();
            services.AddSingleton<IInputManager, InputManager>();
            services.AddSingleton<IRenderer, OmegaTextRenderer>();
            services.AddSingleton<ISceneManager, SceneManager>();

            services.AddSingleton<GameLoop>();

            // Add other services here as needed
            services.AddHostedService<OmegaEngine>();

            return services;
        }
    }
}