//! Make sure to add the following reference to the Project first:
using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine_Tutorial.Scenes;

namespace NekuSoul.SharpDX_Engine_Tutorial
{
    class Programm
    {
        //! This creates a new Game that can be accessed from everywhere.
        public static Game Game = new Game(800, 600);

        static void Main()
        {
            //! This locks the mouse position so that the mouse can't leave the window.
            Game.Input.Mouse.LockMouse = true;
            //! This starts the Game at the mainmenu and makes the window visible.
            Game.Run(new MainMenu());
        }
    }
}