using NekuSoul.SharpDX_Engine.Objects;
using System;

namespace NekuSoul.SharpDX_Engine_Tutorial.Objects.Tornado
{
    //! This is just a part of the Tornado-Magic.
    class Circle : DrawableObject
    {
        public float i = 1;
        public float add = 0.123f;

        public Circle()
        {
            Texture = "Circle";
        }

        public void Update()
        {
            i += add;
            Position.X += (35 * (float)Math.Sin(i)) + 0.6f;
            Position.Y += (35 * (float)Math.Cos(i)) - 0.35f;
        }
    }
}
