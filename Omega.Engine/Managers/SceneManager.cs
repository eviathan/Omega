using Omega.Core.Interfaces;

namespace Omega.Engine.Managers
{
    public class SceneManager : ISceneManager
    {
        public async Task InitialiseAsync(Action<float> updateProgress = null!)
        {
            await Task.Delay(500);
            updateProgress(0.2f);
            
            await Task.Delay(500);
            updateProgress(0.5f);

            await Task.Delay(300);
            updateProgress(1f);
        }
    }
}