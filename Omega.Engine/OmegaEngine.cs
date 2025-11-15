using Microsoft.Extensions.Hosting;
using Omega.Core.Interfaces;
using Spectre.Console;

namespace Omega.Engine
{
    public class OmegaEngine : IHostedService
    {
        private readonly GameLoop _gameLoop;
        private readonly ISceneManager _sceneManager;
        private readonly IInputManager _inputManager;
        private readonly IRenderer _renderer;

        public OmegaEngine(GameLoop gameLoop, ISceneManager sceneManager, IInputManager inputManager, IRenderer renderer)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _sceneManager = sceneManager ?? throw new ArgumentNullException(nameof(sceneManager));
            _inputManager = inputManager ?? throw new ArgumentNullException(nameof(inputManager));
            _renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            LogBanner("𝝮 Omega Engine 𝝮");

            await AnsiConsole.Progress()
                .AutoClear(false)
                .Columns(new ProgressColumn[]
                {
                    new TaskDescriptionColumn(),
                    new ProgressBarColumn(),
                    new SpinnerColumn(),
                })
                .StartAsync(async ctx =>
                {
                    var sceneTask = ctx.AddTask("Initialising Scene Manager...");
                    var inputTask = ctx.AddTask("Initialising Input Manager...");
                    var rendererTask = ctx.AddTask("Initialising Renderer...");

                    var scene = Task.Run(async () =>
                        await _sceneManager.InitialiseAsync((progress) =>
                            sceneTask.Increment(progress * 100)
                        )
                    );

                    var input = Task.Run(async () =>
                    {
                        await _inputManager.InitialiseAsync();
                        await Task.Delay(500);
                        inputTask.Increment(100);
                    });

                    var renderer = Task.Run(async () =>
                    {
                        await _renderer.InitialiseAsync();
                        await Task.Delay(500);
                        rendererTask.Increment(100);
                    });

                    await Task.WhenAll(scene, input, renderer);
                });


            await Task.Run(() => 
                _gameLoop.Run(),
                cancellationToken
            );
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("");
            LogBanner("👋 Goodbye! 👋");
            await Task.FromResult(0);
        }

        // TODO: MOVE THIS!!!
        private static void LogBanner(string text)
        {
            var line = "-------------------------------------------------";
            Console.WriteLine(line);
            Console.WriteLine(text);
            Console.WriteLine(line);
        }
    }
}