using Microsoft.Extensions.Hosting;
using Omega.Extensions;
using Microsoft.Extensions.Logging;
using Omega.Renderer.Text;

namespace Omega.Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => logging.ClearProviders())
                .ConfigureServices(services =>
                {
                    services.AddOmegaEngine((options) =>
                    {
                        options.SetRenderer<OmegaTextRenderer>();
                    });
                })
                .Build()
                .Run();
        }        
    }
}