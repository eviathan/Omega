using Omega.Core.Interfaces;

namespace Omega.Engine.Managers
{
    public class SceneManager : ISceneManager
    {
        public async Task InitialiseAsync()
        {
            await Task.FromResult(0);
        }
    }
}