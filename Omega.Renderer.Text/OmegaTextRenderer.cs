using Omega.Core.Interfaces;

namespace Omega.Renderer.Text
{
    public class OmegaTextRenderer : IRenderer
    {
        public void Initialise(Action<float> updateProgress = null!)
        {
            updateProgress(1f);
        }

        public void Draw()
        {
           
        }

        public void Start()
        {
            // throw new NotImplementedException();
        }
    }
}