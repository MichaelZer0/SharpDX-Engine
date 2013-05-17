using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine_Tutorial.Input;
using NekuSoul.SharpDX_Engine_Tutorial.Objects.Ingame;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
    class Ingame : Scene
    {
        //! This displays the Cursor.
        Cursor Cursor;

        //! A List that contains all Units
        List<Unit> Units;

        //! Defines which AI-Behavior is Active:
        //! 1: Units form a line, following the cursor.
        //! 2: Units try to move away from each other.
        //! 3: Units form a circle.
        //! 4: Every Unit follows a random Unit.
        //! 5: Every Unit follows the cursor.
        int AImode;

        //! The Scenenery is built here.
        public Ingame()
        {
            Cursor = new Cursor();

            //! Creates the first Unit that's following the cursor.
            Units = new List<Unit>();
            Units.Add(new Unit(Cursor));

            AImode = 1;
        }

        public void Update()
        {

            Cursor.UpdatePosition();

            //! If both the Left and Right Mouse-Button are pressed, go back to the Main Menu.
            if (Program.Game.Input.Mouse.CheckLeftMouseDown() && Program.Game.Input.Mouse.CheckMouseRightDown())
            {
                Program.Game.RunScene(new MainMenu());
            }

            //! Spawns a new Unit on Left-Click that is following the last Unit spawned.
            //if (Program.Game.Input.Mouse.CheckLeftMouseClickUp())
            if (Program.Game.Input.Mouse.CheckLeftMouseDown())
            {
                Units.Add(new Unit(Units[Units.Count - 1]));
            }

            //! Switches to the next AI behaviour on Right-Click.
            if (Program.Game.Input.Mouse.CheckMouseRightClickUp())
            {
                Program.Game.Sound.PlaySound("Select");
                switch (AImode)
                {
                    case 1:
                        AImode = 2;
                        break;
                    case 2:
                        Units[0].Target = Units[Units.Count - 1];
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

            //! Moves every Unit according to the current AI behaviour.
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
            //! Draws all the Objects!
            foreach (Unit U in Units)
            {
                Renderer.DrawObject(U);
            }
            Renderer.DrawObject(Cursor);
        }
    }
}
