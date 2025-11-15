using Omega.Core.Interfaces;
using Omega.Renderer.Graphics;

namespace Omega.Engine.Models
{
    public class OmegaOptions
    {
        public Type RendererType { get; private set; }

        public OmegaOptions()
        {
            RendererType = typeof(OmegaGraphicsRenderer);   
        }

        public void SetRenderer<TRenderer>()
            where TRenderer : IRenderer
        {
            RendererType = typeof(TRenderer);
        }
    }
}