using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine.Objects;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine
{
    public interface Scene
    {
        void Update();
        void Draw(RenderHelper Renderer);
    }
}
