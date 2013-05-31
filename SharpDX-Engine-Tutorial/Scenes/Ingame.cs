using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine.Input;
using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine_Tutorial.Objects;
using NekuSoul.SharpDX_Engine_Tutorial.Objects.Ingame;
using System.Collections.Generic;
using System;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
    class Ingame : Scene
    {
        //! This displays the Cursor.
        Cursor Cursor;

        //! A List that contains all Units
        List<Unit> Units;

        //! A List that contains all Icons
        List<Icon> Icons;

        //! Defines which AI-Behavior is Active:
        //! 1: Units form a line, following the cursor.
        //! 2: Units try to move away from each other.
        //! 3: Units form a circle.
        //! 4: Every Unit follows a random Unit.
        //! 5: Every Unit follows the cursor.
        int AImode;

        float Speed = 2f;

        //! The Scenenery is built here.
        public Ingame()
        {
            Cursor = new Cursor();

            //! Creates the first Unit that's following the cursor.
            Units = new List<Unit>();
            Units.Add(new Unit(Cursor));

            Icons = new List<Icon>();
            for (int i = 1; i <= 5; i++)
            {
                Icons.Add(new Icon(i));
            }
            ChangeAIMode(1);
        }

        public void Update()
        {
            //! Exits the game when the Escape Key is pressed.
            if (Program.Game.Input.Keyboard.IsKeyPushedDown(Keyboard.Key.Escape))
            {
                Program.Game.RunScene(new MainMenu());
            }

            Cursor.UpdatePosition();

            //! If both the Left and Right Mouse-Button are pressed, go back to the Main Menu.
            if (Program.Game.Input.Mouse.CheckButtonClickUp(Mouse.Button.LeftMouse) && Program.Game.Input.Mouse.CheckButtonDown(Mouse.Button.RightMouse))
            {
                Program.Game.RunScene(new MainMenu());
            }

            //! Spawns a new Unit on Left-Click that is following the last Unit spawned or spams them with Space.
            if (Program.Game.Input.Mouse.CheckButtonClickDown(Mouse.Button.LeftMouse) || Program.Game.Input.Keyboard.IsKeyDown(Keyboard.Key.Space))
            {
                Units.Add(new Unit(Units[Units.Count - 1]));
            }

            //! Switches AI behaviour based on Key.
            if (Program.Game.Input.Keyboard.IsKeyPushedDown(Keyboard.Key.D1))
            {
                ChangeAIMode(1);
            }
            if (Program.Game.Input.Keyboard.IsKeyPushedDown(Keyboard.Key.D2))
            {
                ChangeAIMode(2);
            }
            if (Program.Game.Input.Keyboard.IsKeyPushedDown(Keyboard.Key.D3))
            {
                ChangeAIMode(3);
            }
            if (Program.Game.Input.Keyboard.IsKeyPushedDown(Keyboard.Key.D4))
            {
                ChangeAIMode(4);
            }
            if (Program.Game.Input.Keyboard.IsKeyPushedDown(Keyboard.Key.D5))
            {
                ChangeAIMode(5);
            }

            //! Changes Game Speed
            if (Program.Game.Input.Keyboard.IsKeyDown(Keyboard.Key.Add))
            {
                if (Speed < 5f)
                {
                    Speed += 0.1f;
                }
            }
            if (Program.Game.Input.Keyboard.IsKeyDown(Keyboard.Key.Subtract))
            {
                if (Speed > 0f)
                {
                    Speed -= 0.1f;
                }
            }

            //! Moves every Unit according to the current AI behaviour.
            foreach (Unit U in Units)
            {
                U.Update();
                U.Texture = "Unit";
                bool HasMoved = false;
                if (U.IsNearUnit(Cursor, 50) && !HasMoved && AImode != 6)
                {
                    U.MoveFromSpecific(Cursor, Speed);
                    //U.Texture = "UnitRed";
                }
                if (AImode != 2)
                {
                    foreach (Unit U2 in Units)
                    {
                        if (U != U2)
                        {
                            if ((U.IsNearUnit(U2, 5) || (U.IsNearUnit(U2, 15) && AImode == 5 && !HasMoved)))
                            {
                                U.MoveFromSpecific(U2, Speed);
                                HasMoved = true;
                                //U.Texture = "UnitRed";
                                break;
                            }
                        }
                    }
                    if (!HasMoved)
                    {
                        U.MoveToTarget(Speed + 0.1f);
                    }
                }
                else
                {
                    foreach (Unit U2 in Units)
                    {
                        if (U != U2)
                        {
                            if (U.IsNearUnit(U2, 50) && !HasMoved)
                            {
                                U.MoveFromSpecific(U2, Speed);
                                //U.Texture = "UnitRed";
                                break;
                            }
                        }
                    }
                }
            }
        }

        //! Changes the AI Behaviour
        public void ChangeAIMode(int NewBahaviour)
        {
            foreach (Icon I in Icons)
            {
                I.Disable();
            }
            Icons[NewBahaviour - 1].Activate();
            Program.Game.Sound.PlaySound("Select");
            switch (NewBahaviour)
            {
                case 1:
                    Units[0].Target = Cursor;
                    for (int i = 1; i < Units.Count; i++)
                    {
                        Units[i].Target = Units[i - 1];
                    }
                    AImode = 1;
                    break;
                case 2:
                    AImode = 2;
                    break;
                case 3:
                    Units[0].Target = Units[Units.Count - 1];
                    for (int i = 1; i < Units.Count; i++)
                    {
                        Units[i].Target = Units[i - 1];
                    }
                    AImode = 3;
                    break;
                case 4:
                    foreach (Unit U in Units)
                    {
                        int NewTarget = Helper.Random.Next(Units.Count - 1);
                        U.Target = Units[NewTarget];
                    }
                    AImode = 4;
                    break;
                case 5:
                    foreach (Unit U in Units)
                    {
                        U.Target = Cursor;
                    }
                    AImode = 5;
                    break;
            }
        }

        public void Draw(RenderHelper Renderer)
        {
            //! Draws all the Objects!
            foreach (Unit U in Units)
            {
                Renderer.DrawObject(U);
            }
            foreach (Icon I in Icons)
            {
                Renderer.DrawObject(I);
            }
            Renderer.DrawText("Speed: " + Math.Round((double)Speed, 3), new Coordinate(0, 64));
            Renderer.DrawObject(Cursor);
        }
    }
}
