using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine_Tutorial.Input;
using NekuSoul.SharpDX_Engine_Tutorial.Objects.Ingame;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
    class Ingame : Scene
    {
        //! This displays the Cursor.
        Cursor Cursor;

        List<Unit> Units;
        Unit FirstUnit;
        bool FollowCursor;

        //! The Scenenery is built here.
        public Ingame()
        {
            Cursor = new Cursor();
            Units = new List<Unit>();
            FirstUnit = new Unit(Cursor);
            Units.Add(FirstUnit);
            FollowCursor = true;
        }

        public void Update()
        {
            Cursor.UpdatePosition();

            if (Programm.Game.Input.Mouse.CheckLeftMouseClickUp())
            {
                Units.Add(new Unit(Units[Units.Count - 1]));
            }

            if (Programm.Game.Input.Mouse.CheckMouseRightClickUp())
            {
                if (FollowCursor)
                {
                    //FirstUnit.Target = Units[Units.Count - 1];
                    FollowCursor = false;
                }
                else
                {
                    //FirstUnit.Target = Cursor;
                    FollowCursor = true;
                }
            }

            foreach (Unit U in Units)
            {
                if (FollowCursor)
                {
                    U.MoveToTarget();
                }
                else
                {
                    U.MoveFromTarget();
                }
            }
        }

        public void Draw(RenderHelper Renderer)
        {
            foreach (Unit U in Units)
            {
                Renderer.DrawObject(U);
            }
            Renderer.DrawObject(Cursor);
        }
    }
}
