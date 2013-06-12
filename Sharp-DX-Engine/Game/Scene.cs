using SharpDX_Engine.Graphics;

namespace SharpDX_Engine
{
    public interface Scene
    {
        void Update();
        void Draw(RenderHelper Renderer);
    }
}
