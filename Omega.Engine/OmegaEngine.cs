using Microsoft.Extensions.Hosting;
using Omega.Core.Interfaces;

namespace Omega.Engine
{
    public class OmegaEngine : IHostedService
    {
        private readonly ISceneManager _sceneManager;
        private readonly IInputManager _inputManager;
        private readonly IRenderer _renderer;

        // private bool _running = false;
        // private double _previousTime;
        // private double _lag = 0.0;
        // private readonly double _fixedTimeStep = 1.0 / 50.0; // 50 Hz physics

        public OmegaEngine(ISceneManager sceneManager, IInputManager inputManager, IRenderer renderer)
        {
            _sceneManager = sceneManager ?? throw new ArgumentNullException(nameof(sceneManager));
            _inputManager = inputManager ?? throw new ArgumentNullException(nameof(inputManager));
            _renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }

        public void Run()
        {
            Console.WriteLine("Why isnt this working?");
            // _running = true;
            // _previousTime = GetCurrentTime();

            // while (_running)
            // {
            //     double currentTime = GetCurrentTime();
            //     double elapsed = currentTime - _previousTime;
            //     _previousTime = currentTime;
            //     _lag += elapsed;

            //     // Stage 1: Input
            //     InputManager.PollInput();

            //     // Stage 2: FixedUpdate
            //     while (_lag >= _fixedTimeStep)
            //     {
            //         SceneManager.CurrentScene.FixedUpdate(_fixedTimeStep);
            //         _lag -= _fixedTimeStep;
            //     }

            //     // Stage 3: Update
            //     SceneManager.CurrentScene.Update(elapsed);

            //     // Stage 4: LateUpdate
            //     SceneManager.CurrentScene.LateUpdate(elapsed);

            //     // Stage 5: Render
            //     Renderer2D.Begin();
            //     SceneManager.CurrentScene.Render();
            //     Renderer2D.End();

            //     // Stage 6: End-of-frame tasks
            //     SceneManager.CurrentScene.EndOfFrame();
            // }
            
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            LogBanner("𝝮 Starting Omega Engine 𝝮");

            await _sceneManager.InitialiseAsync();
            await _inputManager.InitialiseAsync();
            await _renderer.InitialiseAsync();

            // Task.Run(() => 
            //     _gameLoop.Run(), cancellationToken
            // );

            // return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            LogBanner("𝝮 Exiting Omega Engine 𝝮");
            await Task.FromResult(0);
        }

        private double GetCurrentTime()
        {
            return DateTime.Now.Ticks / (double)TimeSpan.TicksPerSecond;
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