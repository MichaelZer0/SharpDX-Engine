using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine_Tutorial.Objects.Tornado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
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
            //if (started)
            {
                i += 0.001f;
                //List<Circle> RemCircles = new List<Circle>();
                foreach (Circle c in Circles)
                {
                    c.Update();
                }
                {
                    Circle C = new Circle();
                    C.Position.X = Program.Game.Input.Mouse.GetCurrentMousePosition().X;
                    C.Position.Y = Program.Game.Input.Mouse.GetCurrentMousePosition().Y;
                    C.add += (float)Math.Tan(i);
                    Circles.Add(C);
                }
            }
        }

        public void Draw(RenderHelper Renderer)
        {
            foreach (Circle C in Circles)
            {
                Renderer.DrawObject(C);
            }
        }
    }
}
