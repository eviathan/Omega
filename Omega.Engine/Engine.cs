using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega.Engine
{
    public class Engine
    {
        // private bool _running = false;
        // private double _previousTime;
        // private double _lag = 0.0;
        // private readonly double _fixedTimeStep = 1.0 / 50.0; // 50 Hz physics

        public void Run()
        {
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

        private double GetCurrentTime()
        {
            return DateTime.Now.Ticks / (double)TimeSpan.TicksPerSecond;
        }
    }
}