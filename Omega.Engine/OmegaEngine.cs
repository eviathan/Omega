using Microsoft.Extensions.Hosting;
using Omega.Core.Interfaces;
using Spectre.Console;
using System.Diagnostics;

namespace Omega.Engine
{
    public class OmegaEngine
    {
        private const int TARGET_FPS = 60;
    
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ISceneManager _sceneManager;
        private readonly IInputManager _inputManager;
        private readonly IRenderer _renderer;

        private bool _isRunning = true;

        public OmegaEngine(
            IHostApplicationLifetime appLifetime,
            ISceneManager sceneManager,
            IInputManager inputManager,
            IRenderer renderer)
        {
            _appLifetime = appLifetime;
            _sceneManager = sceneManager;
            _inputManager = inputManager;
            _renderer = renderer;
                        
            _inputManager.RegisterKeyEvent(ConsoleKey.Q, () =>
            {
                _isRunning = false;
            });
        }

        public async Task RunAsync()
        {
            LogBanner("𝝮 Omega Engine v0.0.1 𝝮");
            Console.WriteLine("Press 'Q' to quit");

            await InitialiseSubsystems();
            await RunGameLoop();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine();
            LogBanner("👋 Goodbye! 👋");
            _isRunning = false;
            return Task.CompletedTask;
        }

        private async Task InitialiseSubsystems()
        {
            await AnsiConsole.Progress()
                .AutoClear(false)
                .Columns(
                [
                    new TaskDescriptionColumn(),
                    new ProgressBarColumn(),
                    new SpinnerColumn(),
                ])
                .Start(async ctx =>
                {
                    var sceneTask    = ctx.AddTask("Initialising Scene Manager...");
                    var inputTask    = ctx.AddTask("Initialising Input Manager...");
                    var rendererTask = ctx.AddTask("Initialising Renderer...");

                    _sceneManager.Initialise(progress => 
                        sceneTask.Increment(progress * 100)
                    );

                    _inputManager.Initialise(progress => 
                        inputTask.Increment(progress * 100)
                    );

                    _renderer.Initialise(progress => 
                        rendererTask.Increment(progress * 100)
                    );
                });
        }

        private async Task RunGameLoop()
        {
            AnsiConsole.MarkupLine("[bold green]Starting[/] [white]Engine![/]");

            var stopwatch = new Stopwatch();
            var frameTime = 1000.0 / TARGET_FPS;

            _sceneManager.Start();
            _renderer.Start();

            while (_isRunning)
            {
                stopwatch.Restart();

                // Input
                _inputManager.Update();

                // Update
                _sceneManager.Update();

                // Render
                _renderer.Draw();

                // FPS timing
                var elapsed = stopwatch.ElapsedMilliseconds;
                if (elapsed < frameTime)
                {
                    var delay = frameTime - elapsed;
                    try
                    {
                        await Task.Delay((int)delay);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                }
            }

            _appLifetime.StopApplication();
            AnsiConsole.MarkupLine("[bold red]Stopping[/] [white]Engine![/]");
            await Task.Yield();
        }

        private static void LogBanner(string text)
        {
            var line = "-------------------------------------------------";
            Console.WriteLine(line);
            Console.WriteLine(text);
            Console.WriteLine(line);
        }
    }
}
