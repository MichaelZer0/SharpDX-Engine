using NekuSoul.SharpDX_Engine.Objects;
using System.Collections.Generic;
using NekuSoul.SharpDX_Engine.Input;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
    class MainMenu : SharpDX_Engine.Scene
    {
        //! This are the entries for the mainmenu.
        //! We use SimpleDrawableObject because there will be no code behind these objects.
        SimpleDrawableObject MainMenuStart;
        SimpleDrawableObject MainMenuExit;

        //! This list contains all objects that should be drawn on the screen.
        List<DrawableObject> ObjectsToDraw = new List<DrawableObject>();

        //! The Scenenery is built here.
        public MainMenu()
        {
            MainMenuStart = new SimpleDrawableObject()
            {
                Texture = "StartA",
                Position = new Rectangle(50, 50, 100, 50)
            };
            ObjectsToDraw.Add(MainMenuStart);

            MainMenuExit = new SimpleDrawableObject()
            {
                Texture = "ExitA",
                Position = new Rectangle(50, 110, 100, 50)
            };
            ObjectsToDraw.Add(MainMenuExit);
        }

        //! This method is called 60 times per second and contains the logic for the scene.
        public override void Update()
        {
            
        }

        //! This method is called to draw the scene and returns all objects that should get drawn.
        public override List<DrawableObject> Draw()
        {
            return ObjectsToDraw;
        }
    }
}
