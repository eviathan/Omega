using Omega.Core.Interfaces;
using Omega.Engine.Managers;
using Omega.Renderer.Graphics;

namespace Omega.Engine.Models
{
    public class OmegaOptions
    {
        public Type SceneManagerType { get; private set; }
        public Type InputManagerType { get; private set; }
        public Type RendererType { get; private set; }

        public OmegaOptions()
        {
            SceneManagerType = typeof(SceneManager);  
            InputManagerType = typeof(InputManager);  
            RendererType = typeof(OmegaGraphicsRenderer);
        }

        public void SetSceneManager<TSceneManager>()
            where TSceneManager : ISceneManager
        {
            SceneManagerType = typeof(TSceneManager);
        }

        public void SetInputManager<TInputManager>()
            where TInputManager : IInputManager
        {
            InputManagerType = typeof(TInputManager);
        }

        public void SetRenderer<TRenderer>()
            where TRenderer : IRenderer
        {
            RendererType = typeof(TRenderer);
        }
    }
}