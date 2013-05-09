using NekuSoul.SharpDX_Engine.Objects;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine_Tutorial.Scenes
{
    class MainMenu : SharpDX_Engine.Scene
    {
        //! The Scene is built here
        public MainMenu()
        {
            
        }

        //! This method is called 60 times per second and contains the logic for the scene.
        public override void Update()
        {

        }

        //! This method is called to draw the Scene and returns all objects that should get drawn.
        public override List<DrawableObject> Draw()
        {
            return new List<DrawableObject>();
        }
    }
}
