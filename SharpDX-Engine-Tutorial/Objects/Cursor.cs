using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine_Tutorial;
using NekuSoul.SharpDX_Engine.Utitities;

namespace NekuSoul.SharpDX_Engine_Tutorial.Objects
{
    public class Cursor : DrawableObject
    {
        public Cursor()
        {
            Texture = "Cursor";
            Position = Program.Game.Input.Mouse.GetCurrentMousePosition();
            Size = new SharpDX_Engine.Utitities.Size(12, 19);
        }

        public void UpdatePosition()
        {
            //! Moves the Cursor according to the mouse-movement.
            Position += Program.Game.Input.Mouse.GetCurrentMousePosition();

            //! Cages the Cursor into the windows.
            if (Position.X < 0)
            {
                Position.X = 0;
            }
            if (Position.Y < 0)
            {
                Position.Y = 0;
            }
            if (Position.X > Program.Size.width)
            {
                Position.X = Program.Size.width;
            }
            if (Position.Y > Program.Size.height)
            {
                Position.Y = Program.Size.height;
            }
        }
    }
}
