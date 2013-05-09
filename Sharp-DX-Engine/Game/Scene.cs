using NekuSoul.SharpDX_Engine.Objects;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine
{
    public abstract class Scene
    {
        public abstract void Update();
        public abstract List<DrawableObject> Draw();
    }
}
