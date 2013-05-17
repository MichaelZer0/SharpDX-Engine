using NekuSoul.SharpDX_Engine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NekuSoul.SharpDX_Engine_Tutorial.Objects.Tornado
{
    class Circle : DrawableObject
    {
        public float i = 1;
        public float add = 0.123f;

        public Circle()
        {
            Texture = "Unit";
        }

        public void Update()
        {
            i += add;
            Position.X = (135 * (float)Math.Sin(i)) + 0.6f;
            Position.Y = (135 * (float)Math.Cos(i)) - 0.35f;
        }
    }
}
