using System.Diagnostics;
using Omega.Core.Interfaces;
using Spectre.Console;

namespace Omega.Engine
{
    public class GameLoop
    {
        const int TARGET_FPS = 60;
        
        private readonly IInputManager _inputManager;
        private readonly ISceneManager _sceneManager;
        private readonly IRenderer _renderer;

        // private bool _running = false;
        // private double _previousTime;
        // private double _lag = 0.0;
        // private readonly double _fixedTimeStep = 1.0 / 50.0; // 50 Hz physics

        public GameLoop(IInputManager inputManager, ISceneManager sceneManager, IRenderer renderer)
        {
            _inputManager = inputManager;
            _sceneManager = sceneManager;
            _renderer = renderer;
        }

        public void Run()
        {
            AnsiConsole.Write(new Markup("[bold yellow]Starting[/] [red]Game Loop![/]"));

            // Console.WriteLine("Starting Game Loop");
            // var stopwatch = new Stopwatch();
            // var frameTime = 1000.0 / TARGET_FPS;

            // while (true)
            // {
            //     stopwatch.Restart();

            //     // 1. Input
            //     _inputManager.Update();

            //     // 2. Update
            //     _sceneManager.Update();

            //     // 3. Render
            //     _renderer.Render();

            //     // Sleep to maintain FPS
            //     var elapsed = stopwatch.ElapsedMilliseconds;
            //     if (elapsed < frameTime)
            //         Thread.Sleep((int)(frameTime - elapsed));
            // }
        }

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

        // private double GetCurrentTime()
        // {
        //     return DateTime.Now.Ticks / (double)TimeSpan.TicksPerSecond;
        // }
    }
}