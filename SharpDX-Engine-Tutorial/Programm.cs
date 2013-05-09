//! Make sure to add the following reference to the Project first:
using NekuSoul.SharpDX_Engine;
using NekuSoul.SharpDX_Engine_Tutorial.Scenes;

namespace NekuSoul.SharpDX_Engine_Tutorial
{
    class Programm
    {
        static void Main()
        {
            //! This creates a new Game. 
            Game Game = new Game(800, 600);
            //! This starts the Game and makes the window visible.
            Game.Run();
            //! This changes the game's scene to the main-menu.
            Game.RunScene(new MainMenu());
        }
    }
}
