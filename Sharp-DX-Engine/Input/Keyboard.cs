using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine;
using SharpDX.DirectInput;

namespace NekuSoul.SharpDX_Engine.Input
{
    public class Keyboard
    {
        SharpDX.DirectInput.Keyboard _Keyboard;
        KeyboardState CurrentState;
        KeyboardState LastState;

        public Keyboard(DirectInput DirectInput)
        {
            _Keyboard = new SharpDX.DirectInput.Keyboard(DirectInput);
            _Keyboard.Acquire();
            UpdateKeyboardState();
        }

        public void UpdateKeyboardState()
        {
            LastState = CurrentState;
            CurrentState = CurrentState = _Keyboard.GetCurrentState();
        }

        public bool IsKeyDown()
        {
            if (CurrentState.AllKeys.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
