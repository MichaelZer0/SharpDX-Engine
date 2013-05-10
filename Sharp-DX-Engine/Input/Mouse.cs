using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine;
using SharpDX.DirectInput;
using System.Drawing;
using System.Windows.Forms;

namespace NekuSoul.SharpDX_Engine.Input
{
    public class Mouse
    {
        public bool FormHasFocus = true;
        public bool LockMouse = false;

        internal Point Point = new Point();
        private SharpDX.DirectInput.Mouse _Mouse = new SharpDX.DirectInput.Mouse(new DirectInput());
        private MouseState CurrentState;
        private MouseState LastState;

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
            if (LockMouse && FormHasFocus)
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

        public bool IsMouseDown()
        {
            return CurrentState.Buttons[0];
        }

        public bool IsMouseClickDown()
        {
            if (!LastState.Buttons[0])
            {
                return CurrentState.Buttons[0];
            }
            return false;
        }

        public bool IsMouseClickUp()
        {
            if (LastState.Buttons[0])
            {
                return !CurrentState.Buttons[0];
            }
            return false;
        }
    }
}
