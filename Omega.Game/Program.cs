using Microsoft.Extensions.Hosting;
using Omega.Engine.Extensions;

namespace Omega.Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddOmegaEngine();
                })
                .Build()
                .Run();
        }        
    }
}