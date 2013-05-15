using SharpDX.DirectInput;
namespace NekuSoul.SharpDX_Engine.Input
{
    public class InputManager
    {
        private DirectInput DirectInput = new DirectInput();
        public Keyboard Keyboard;
        public Mouse Mouse;
        public Gamepad Gamepad;

        public InputManager()
        {
            Keyboard = new Keyboard(DirectInput);
            Mouse = new Mouse(DirectInput);
            Gamepad = new Gamepad();
        }
    }
}
