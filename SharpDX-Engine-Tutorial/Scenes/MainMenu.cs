using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine.Input;
using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine_Tutorial.Objects;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
    class MainMenu : Scene
    {
        //! This are the entries for the mainmenu.
        //! We use SimpleDrawableObject because there will be no code behind these objects.
        SimpleDrawableObject MainMenuStart;
        SimpleDrawableObject MainMenuExit;

        //! We do this just because we can put a Scene in a Scene.
        Scene Background;

        //! This displays the Cursor.
        Cursor Cursor;

        //! The Scenenery is built here.
        public MainMenu()
        {
            Background = new Tornado();

            //! Creates the Start- and Exit-Button.
            MainMenuStart = new SimpleDrawableObject()
            {
                Texture = "StartA",
                Size = new Size(100f, 50f)
            };
            MainMenuStart.Position = new Coordinate((Program.Size.width / 2) - (MainMenuStart.Size.width / 2), (Program.Size.height / 2) - (MainMenuStart.Size.height));


            MainMenuExit = new SimpleDrawableObject()
            {
                Texture = "ExitA",
                Size = new Size(100f, 50f)
            };
            MainMenuExit.Position = new Coordinate((Program.Size.width / 2) - (MainMenuExit.Size.width / 2), (Program.Size.height / 2) + (MainMenuExit.Size.height));


            //! Creates a Cursor.
            Cursor = new Cursor();
        }

        //! This method is called 60 times per second and contains the logic for the scene.
        public void Update()
        {
            //! We have to update the Background as well.
            Background.Update();

            //! Starts the game when the return Key is pressed.
            if (Program.Game.Input.Keyboard.IsKeyPushedDown(Keyboard.Key.Return))
            {
                Program.Game.RunScene(new Ingame());
            }

            //! Exits the game when the Escape Key is pressed.
            if (Program.Game.Input.Keyboard.IsKeyPushedDown(Keyboard.Key.Escape))
            {
                //! Closes the Game
                Program.Game.Close();
            }

            //! Updates the Cursorposition.
            Cursor.UpdatePosition();

            //! When the Mouse hovers over a button, make it react.
            if (Cursor.Position.IsWithinDrawableObject(MainMenuStart))
            {
                //! Swaps out the Texture.
                MainMenuStart.Texture = "StartB";

                //! Checks if the Left Mouse-Button has been clicked.
                if (Program.Game.Input.Mouse.CheckButtonClickUp(Mouse.Button.LeftMouse))
                {
                    //! Switches from the MainMenu to Ingame.
                    Program.Game.RunScene(new Ingame());
                    Program.Game.Sound.PlaySound("Select");
                }
            }
            else
            {
                MainMenuStart.Texture = "StartA";
            }
            if (Cursor.Position.IsWithinDrawableObject(MainMenuExit))
            {
                MainMenuExit.Texture = "ExitB";
                if (Program.Game.Input.Mouse.CheckButtonClickUp(Mouse.Button.LeftMouse))
                {
                    //! Closes the Game
                    Program.Game.Close();
                }
            }
            else
            {
                MainMenuExit.Texture = "ExitA";
            }
        }

        public void Draw(RenderHelper Renderer)
        {
            //! At first the Background-Scene!
            Background.Draw(Renderer);

            //! Then draw all the Objects!
            Renderer.DrawObject(MainMenuStart);
            Renderer.DrawObject(MainMenuExit);
            Renderer.DrawObject(Cursor);
        }
    }
}
