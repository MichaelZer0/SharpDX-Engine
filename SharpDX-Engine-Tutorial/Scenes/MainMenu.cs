using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine_Tutorial.Input;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
    class MainMenu : Scene
    {
        //! This are the entries for the mainmenu.
        //! We use SimpleDrawableObject because there will be no code behind these objects.
        SimpleDrawableObject MainMenuStart;
        SimpleDrawableObject MainMenuExit;

        //! This displays the Cursor.
        Cursor Cursor;

        //! The Scenenery is built here.
        public MainMenu()
        {
            MainMenuStart = new SimpleDrawableObject()
            {
                Texture = "StartA",
                Position = new Coordinate(50f, 50f),
                Size = new Size(100f, 50f)
            };

            MainMenuExit = new SimpleDrawableObject()
            {
                Texture = "ExitA",
                Position = new Coordinate(50f, 110f),
                Size = new Size(100f, 50f)
            };

            Cursor = new Cursor();
        }

        //! This method is called 60 times per second and contains the logic for the scene.
        public void Update()
        {
            Cursor.UpdatePosition();
            if (Cursor.Position.IsWithinDrawableObject(MainMenuStart))
            {
                MainMenuStart.Texture = "StartB";
                if (Programm.Game.Input.Mouse.CheckLeftMouseClickUp())
                {
                    Programm.Game.RunScene(new Ingame());
                }
            }
            else
            {
                MainMenuStart.Texture = "StartA";
            }
            if (Cursor.Position.IsWithinDrawableObject(MainMenuExit))
            {
                MainMenuExit.Texture = "ExitB";
                if (Programm.Game.Input.Mouse.CheckLeftMouseClickUp())
                {
                    Programm.Game.Close();
                }
            }
            else
            {
                MainMenuExit.Texture = "ExitA";
            }
        }

        public void Draw(RenderHelper Renderer)
        {
            Renderer.DrawObject(MainMenuStart);
            Renderer.DrawObject(MainMenuExit);
            Renderer.DrawObject(Cursor);
        }
    }
}
