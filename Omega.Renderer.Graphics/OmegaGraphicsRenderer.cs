using Omega.Core.Interfaces;
using Omega.Core.Models;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Omega.Renderer.Graphics
{
    public class OmegaGraphicsRenderer : IRenderer
    {
        private static IWindow? _window;

        private readonly RendererOptions _options;

        public OmegaGraphicsRenderer(RendererOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Initialise(Action<float> updateProgress = null!)
        {
            var options = WindowOptions.Default with
            {
                Size = new Vector2D<int>(800, 600),
                Title = _options.Title
            };

            _window = Window.Create(options);
        }

        public void Start()
        {
            _window?.Run();
        }

        public void Draw()
        {
           
        }
    }
}