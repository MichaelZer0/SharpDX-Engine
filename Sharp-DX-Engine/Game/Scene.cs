using SharpDX_Engine.Graphics;

namespace SharpDX_Engine
{
    public interface Scene
    {
        void Update();
        void Draw(RenderHelper Renderer);
    }

    class DummyScene : Scene
    {
        public void Update()
        { }

        public void Draw(RenderHelper Renderer)
        { }
    }
}
