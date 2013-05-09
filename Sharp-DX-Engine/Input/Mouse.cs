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
        MouseState _CurrentState;
        MouseState _LastState;
        Point _Point = new Point();
        Game _Game;

        public Mouse(Game _Game)
        {
            this._Game = _Game;
            _Mouse.Acquire();
            UpdateMouseState();
            _Game.form.Move += form_Move;
            Cursor.Hide();
        }

        /// <summary>
        /// Sets new Lock-Position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void form_Move(object sender, System.EventArgs e)
        {
            UpdateMouseLock();
        }

        /// <summary>
        /// Resets Mouse Position to simulate Mouse-Lock
        /// </summary>
        public void UpdateMouseLock()
        {
            _Point = new Point(_Game.form.Location.X + (_Game.form.Size.Width / 2), _Game.form.Location.Y + (_Game.form.Size.Height / 2));
        }

        public void UpdateMouseState()
        {
            _LastState = _CurrentState;
            _CurrentState = _CurrentState = _Mouse.GetCurrentState();
            if (LockMouse && Mouse.FormHasFocus)
            {
                Cursor.Position = _Point;
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
