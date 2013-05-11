using System;
using SharpDX.XInput;

namespace NekuSoul.SharpDX_Engine.Input
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
        public bool CheckGamepadButton(GamepadButton Button)
        {
            GamepadButtonFlags CheckButton = GamepadButtonFlags.None;
            switch (Button)
            {
                case GamepadButton.A:
                    {
                        CheckButton = GamepadButtonFlags.A;
                        break;
                    }
            }
            return Controller.GetState().Gamepad.Buttons == CheckButton;
        }

        public enum GamepadButton
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
