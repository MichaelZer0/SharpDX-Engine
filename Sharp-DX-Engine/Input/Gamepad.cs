using SharpDX.XInput;

namespace SharpDX_Engine.Input
{
    public class Gamepad
    {
        private SharpDX.XInput.Controller Controller;
        private State CurrentState;
        private State LastState;

        public Gamepad()
        {
            Controller = new SharpDX.XInput.Controller(UserIndex.One);
        }

        public void UpdateGamepadState()
        {
            if (Controller.IsConnected)
            {
                LastState = CurrentState;
                CurrentState = Controller.GetState();
            }
        }

        /// <summary>
        /// Returns current Mouse-Position
        /// </summary>
        /// <returns></returns>
        public bool CheckGamepadButton(Button Button)
        {
            if (Controller.IsConnected)
            {
                GamepadButtonFlags CheckButton = GamepadButtonFlags.None;
                switch (Button)
                {
                    case Button.A:
                        {
                            CheckButton = GamepadButtonFlags.A;
                            break;
                        }
                }
                return Controller.GetState().Gamepad.Buttons == CheckButton;
            }
            return false;
        }

        public enum Button
        {
            A,
            B,
            X,
            Y,
            LT,
            RT,
            LS,
            RS,
            BACK,
            START,
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

    }
}
