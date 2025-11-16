using Omega.Core.Interfaces;

namespace Omega.Engine.Managers
{
    public class SceneManager : ISceneManager
    {
        public void Initialise(Action<float> updateProgress = null!)
        {
            updateProgress(1f);
        }

        public void Start()
        {
        }

        public void Update()
        {
           
        }
    }
}