using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine_Tutorial;
using NekuSoul.SharpDX_Engine.Utitities;

namespace NekuSoul.SharpDX_Engine_Tutorial.Input
{
    public class Cursor : DrawableObject
    {
        public Cursor()
        {
            Texture = "Cursor";
            Position = Programm.Game.Input.Mouse.GetCurrentMousePosition();
            Size = new SharpDX_Engine.Utitities.Size(12, 19);
        }

        public void UpdatePosition()
        {
            Position += Programm.Game.Input.Mouse.GetCurrentMousePosition();
            if (Position.X < 0)
            {
                Position.X = 0;
            }
            if (Position.Y < 0)
            {
                Position.Y = 0;
            }
            if (Position.X > Programm.Size.width)
            {
                Position.X = Programm.Size.width;
            }
            if (Position.Y > Programm.Size.height)
            {
                Position.Y = Programm.Size.height;
            }
        }
    }
}
