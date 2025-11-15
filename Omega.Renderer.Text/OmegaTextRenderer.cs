using Omega.Core.Interfaces;

namespace Omega.Renderer.Text
{
    public class OmegaTextRenderer : IRenderer
    {
        public async Task InitialiseAsync()
        {
            await Task.FromResult(0);
        }
    }
}