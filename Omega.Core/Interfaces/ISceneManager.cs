namespace Omega.Core.Interfaces
{
    public interface ISceneManager
    {
        void Initialise(Action<float> updateProgress = null!);
        void Start();
        void Update();
    }
}