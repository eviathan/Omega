using Omega.Core.Interfaces;

namespace Omega.Renderer.Text
{
    public class OmegaTextInputManager : IInputManager
    {
        private Dictionary<ConsoleKey, Action> _keyEventHandlers { get; set; } = [];

        public OmegaTextInputManager() { }

        public void Initialise(Action<float> updateProgress = null!)
        {
            
            
            // await Task.Delay(500);
            // updateProgress(0.2f);
            
            // await Task.Delay(500);
            // updateProgress(0.5f);

            // await Task.Delay(300);
            updateProgress(1f);
        }
        
        public void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                OnKeyDown(key);
            }
        }

        public void RegisterKeyEvent(ConsoleKey key, Action action)
        {
            _keyEventHandlers[key] = action;
        }

        private void OnKeyDown(ConsoleKey key = default)
        {
            if (key != default && _keyEventHandlers.TryGetValue(key, out var action))
                action();
        }

        private void OnKeyUp(ConsoleKey key = default)
        {
           
        }
    }
}