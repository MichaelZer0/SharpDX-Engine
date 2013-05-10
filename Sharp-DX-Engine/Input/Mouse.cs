using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine;
using SharpDX.DirectInput;
using System.Drawing;
using System.Windows.Forms;

namespace NekuSoul.SharpDX_Engine.Input
{

    public class Mouse
    {
        public static bool FormHasFocus = true;

        public bool LockMouse;

        SharpDX.DirectInput.Mouse _Mouse = new SharpDX.DirectInput.Mouse(new DirectInput());
        MouseState CurrentState;
        MouseState LastState;
        internal Point Point = new Point();

        public Mouse()
        {
            _Mouse.Acquire();
            UpdateMouseState();
            Cursor.Hide();
        }

        public void UpdateMouseState()
        {
            LastState = CurrentState;
            CurrentState = CurrentState = _Mouse.GetCurrentState();
            if (LockMouse && Mouse.FormHasFocus)
            {
                Cursor.Position = Point;
            }
        }

        /// <summary>
        /// Returns current Mouse-Position
        /// </summary>
        /// <returns></returns>
        public Coordinate GetCurrentMousePosition()
        {
            return new Coordinate()
            {
                X = CurrentState.X,
                Y = CurrentState.Y
            };
        }

        public Coordinate GetLastMousePosition()
        {
            return new Coordinate()
            {
                X = LastState.X,
                Y = LastState.Y
            };
        }
    }
}
