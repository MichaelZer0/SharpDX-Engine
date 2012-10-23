﻿using NekuSoul.SharpDX_Engine.Objects;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine
{
    public abstract class Scene
    {
        public List<DrawableObject> DrawableObjectList = new List<DrawableObject>();

        public abstract void Update();
    }
}
