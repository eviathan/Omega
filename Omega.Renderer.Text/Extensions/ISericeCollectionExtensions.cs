using Microsoft.Extensions.DependencyInjection;
using Omega.Core.Interfaces;
using Omega.Renderer.Text;

namespace Omega.Extensions
{
    public static class ISericeCollectionExtensions
    {
        public static IServiceCollection AddOmegaTextRenderer(this IServiceCollection services)
        {
            services.AddSingleton<IRenderer, OmegaTextRenderer>();

            return services;
        }
    }
}