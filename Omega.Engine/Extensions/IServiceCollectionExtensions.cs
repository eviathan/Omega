using Microsoft.Extensions.DependencyInjection;
using Omega.Core.Interfaces;
using Omega.Engine;
using Omega.Engine.Managers;
using Omega.Engine.Models;
using Omega.Renderer.Graphics;

namespace Omega.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddOmegaEngine(this IServiceCollection services, Action<OmegaOptions>? configure = null)
        {
            // Configure Options
            var options = new OmegaOptions();
            configure?.Invoke(options);
            
            services.AddSingleton(options);
            services.AddSingleton(typeof(ISceneManager), options.SceneManagerType);
            services.AddSingleton(typeof(IInputManager), options.InputManagerType);

            services.AddSingleton(typeof(IRenderer), options.RendererType);
            services.AddSingleton(options.RendererOptions);
            
            // Service Registrations 
            services.AddSingleton<OmegaEngine>();

            return services;
        }
    }
}