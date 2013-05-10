using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine_Tutorial;

namespace NekuSoul.SharpDX_Engine_Tutorial.Input
{
    public class Cursor:DrawableObject
    {
        public Cursor()
        {
            Texture = "Cursor";
            Position = Programm.Game.Input.Mouse.GetCurrentMousePosition();
        }
    }
}
