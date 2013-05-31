using NekuSoul.SharpDX_Engine.Graphics;

namespace NekuSoul.SharpDX_Engine
{
    public interface Scene
    {
        void Update();
        void Draw(RenderHelper Renderer);
    }
}
