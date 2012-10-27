using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine;
using SharpDX.DirectInput;
using System.Drawing;
using System.Windows.Forms;

namespace NekuSoul.SharpDX_Engine.Input
{
    public class Mouse
    {
        public bool LockMouse;

        SharpDX.DirectInput.Mouse _Mouse = new SharpDX.DirectInput.Mouse(new DirectInput());
        MouseState _CurrentState;
        MouseState _LastState;
        Point _Point = new Point();

        public Mouse()
        {
            _Mouse.Acquire();
            UpdateMouseState();
            Game.form.Move += form_Move;
            Cursor.Hide();
        }

        void form_Move(object sender, System.EventArgs e)
        {
            _Point = new Point(Game.form.Location.X + (Game.form.Size.Width / 2), Game.form.Location.Y + (Game.form.Size.Height / 2));
        }

        public void UpdateMouseState()
        {
            _LastState = _CurrentState;
            _CurrentState = _CurrentState = _Mouse.GetCurrentState();
            if (LockMouse)
            {
                Cursor.Position = _Point;
            }
        }

        public Coordinate GetCurrentMousePosition()
        {
            return new Coordinate()
            {
                X = _LastState.X,
                Y = _CurrentState.Y
            };
        }

        public Coordinate GetLastMousePosition()
        {
            return new Coordinate()
            {
                X = _LastState.X,
                Y = _CurrentState.Y
            };
        }
    }
}
