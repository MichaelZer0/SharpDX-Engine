using SharpDX_Engine;
using SharpDX_Engine.Graphics;
using SharpDX_Engine_Tutorial.Objects.Tornado;
using System;
using System.Collections.Generic;

namespace SharpDX_Engine_Tutorial.Scenes
{
    //! Magically draws a Tornado on the screen.
    class Tornado : Scene
    {
        List<Circle> Circles;
        float i = 0;

        public Tornado()
        {
            Circles = new List<Circle>();
        }

        public void Update()
        {
            i += 0.001f;
            foreach (Circle Circle in Circles)
            {
                Circle.Update();
            }
            Circle NewCircle = new Circle();
            NewCircle.Position.X = 30;
            NewCircle.Position.Y = Program.Size.height - 20;
            NewCircle.add += (float)Math.Tan(i);
            Circles.Add(NewCircle);
        }

        public void Draw(RenderHelper Renderer)
        {
            foreach (Circle Circle in Circles.ToArray())
            {
                Renderer.DrawObject(Circle);
            }
        }
    }
}
