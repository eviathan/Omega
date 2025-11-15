namespace Omega.Core.Interfaces
{
    public interface ISceneManager
    {
        Task InitialiseAsync(Action<float> updateProgress = null!);
    }
}