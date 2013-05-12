using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine_Tutorial.Input;
using NekuSoul.SharpDX_Engine_Tutorial.Objects.Ingame;
using NekuSoul.SharpDX_Engine.Utitities;
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

            if (Program.Game.Input.Mouse.CheckLeftMouseDown() && Program.Game.Input.Mouse.CheckMouseRightDown())
            {
                Program.Game.RunScene(new MainMenu());
            }

            if (Program.Game.Input.Mouse.CheckLeftMouseClickUp())
            {
                Units.Add(new Unit(Units[Units.Count - 1]));
            }

            if (Program.Game.Input.Mouse.CheckMouseRightClickUp())
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
                        foreach (Unit U in Units)
                        {
                            int NewTarget = Helper.Random.Next(Units.Count - 1);
                            U.Target = Units[NewTarget];
                        }
                        AImode = 4;
                        break;
                    case 4:
                        foreach (Unit U in Units)
                        {
                            U.Target = Cursor;
                        }
                        AImode = 5;
                        break;
                    case 5:
                        for (int i = 1; i < Units.Count; i++)
                        {
                            Units[i].Target = Units[i - 1];
                        }
                        AImode = 1;
                        break;
                }
            }

            foreach (Unit U in Units)
            {
                if (AImode != 1 && AImode != 5)
                {
                    U.MoveFromSpecific(Cursor, 50);
                }
                if (AImode == 2)
                {
                    foreach (Unit U2 in Units)
                    {
                        if (U != U2)
                        {
                            U.MoveFromSpecific(U2, 50);
                        }
                        U.MoveFromSpecific(Cursor, 50);
                    }
                }
                else
                {
                    U.MoveToTarget();
                    foreach (Unit U2 in Units)
                    {
                        if (U != U2 && U2 != U.Target)
                        {
                            if (AImode == 5)
                            {
                                U.MoveFromSpecific(U2, 15);
                            }
                            else
                            {
                                U.MoveFromSpecific(U2, 5);
                            }
                        }
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
