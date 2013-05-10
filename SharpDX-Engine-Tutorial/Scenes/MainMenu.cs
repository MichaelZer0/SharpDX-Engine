using NekuSoul.SharpDX_Engine.Objects;
using System.Collections.Generic;
using NekuSoul.SharpDX_Engine.Input;
using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine_Tutorial.Input;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
    class MainMenu : SharpDX_Engine.Scene
    {
        //! This are the entries for the mainmenu.
        //! We use SimpleDrawableObject because there will be no code behind these objects.
        SimpleDrawableObject MainMenuStart;
        SimpleDrawableObject MainMenuExit;

        //! This displays the Cursor.
        Cursor Cursor;

        //! This list contains all objects that should be drawn on the screen.
        List<DrawableObject> ObjectsToDraw = new List<DrawableObject>();

        //! The Scenenery is built here.
        public MainMenu()
        {
            MainMenuStart = new SimpleDrawableObject()
            {
                Texture = "StartA",
                Position = new Coordinate(50f, 50f),
                Size = new Size(100f, 50f)
            };
            ObjectsToDraw.Add(MainMenuStart);

            MainMenuExit = new SimpleDrawableObject()
            {
                Texture = "ExitA",
                Position = new Coordinate(50f, 110f),
                Size = new Size(100f, 50f)
            };
            ObjectsToDraw.Add(MainMenuExit);

            Cursor = new Cursor();
            ObjectsToDraw.Add(Cursor);
        }

        //! This method is called 60 times per second and contains the logic for the scene.
        public override void Update()
        {
            Cursor.UpdatePosition();
            if (Cursor.Position.IsWithinDrawableObject(MainMenuStart))
            {
                MainMenuStart.Texture = "StartB";
                if (Programm.Game.Input.Mouse.IsMouseClickUp())
                {

                }
            }
            else
            {
                MainMenuStart.Texture = "StartA";
            }
            if (Cursor.Position.IsWithinDrawableObject(MainMenuExit))
            {
                MainMenuExit.Texture = "ExitB";
                if (Programm.Game.Input.Mouse.IsMouseClickUp())
                {
                    Programm.Game.Close();
                }
            }
            else
            {
                MainMenuExit.Texture = "ExitA";
            }
        }

        //! This method is called to draw the scene and returns all objects that should get drawn.
        public override List<DrawableObject> Draw()
        {
            return ObjectsToDraw;
        }
    }
}
