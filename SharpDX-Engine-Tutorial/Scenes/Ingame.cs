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
        int AImode;

        //! The Scenenery is built here.
        public Ingame()
        {
            Cursor = new Cursor();
            Units = new List<Unit>();
            FirstUnit = new Unit(Cursor);
            Units.Add(FirstUnit);
            AImode = 1;
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
                switch (AImode)
                {
                    case 1:
                        AImode = 2;
                        break;
                    case 2:
                        FirstUnit.Target = Units[Units.Count - 1];
                        AImode = 3;
                        break;
                    case 3:
                        FirstUnit.Target = Cursor;
                        AImode = 1;
                        break;
                }
            }

            foreach (Unit U in Units)
            {
                if (AImode == 1 || AImode == 3)
                {
                    U.MoveToTarget();
                    foreach (Unit U2 in Units)
                    {
                        if (U != U2 && U2 != U.Target)
                        {
                            U.MoveFromSppecific(U2, 5);
                        }
                    }
                }
                if (AImode == 2)
                {
                    foreach (Unit U2 in Units)
                    {
                        if (U != U2)
                        {
                            U.MoveFromSppecific(U2, 50);
                        }
                        U.MoveFromSppecific(Cursor, 50);
                    }
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
