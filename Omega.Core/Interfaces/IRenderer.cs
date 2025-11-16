namespace Omega.Core.Interfaces
{
    public interface IRenderer
    {
        void Initialise(Action<float> updateProgress = null!);

        void Start();
        void Draw();
    }
}