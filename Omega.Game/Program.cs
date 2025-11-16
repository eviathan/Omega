using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Omega.Extensions;
using Omega.Renderer.Text;
using Omega.Engine;
using Omega.Engine.Managers;
using Omega.Renderer.Graphics;

namespace Omega.Game
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => logging.ClearProviders())
                .ConfigureServices(services =>
                {
                    services.AddOmegaEngine((options) =>
                    {
                        // options.SetRenderer<OmegaTextRenderer>();
                        // options.SetInputManager<OmegaTextInputManager>();

                        options.SetRenderer<OmegaGraphicsRenderer>(options =>
                        {
                            options.Title = "Omega";
                        });

                        options.SetInputManager<InputManager>();
                    });
                })
                .Build();

            var engine = host.Services.GetRequiredService<OmegaEngine>();
            await engine.RunAsync();
        }        
    }
}