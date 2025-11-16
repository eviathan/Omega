namespace Omega.Core.Interfaces
{
    public interface IInputManager
    {
        void Initialise(Action<float> updateProgress = null!);

        void Update();

        public void RegisterKeyEvent(ConsoleKey key, Action action);
    }
}