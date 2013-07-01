using SharpDX_Engine.Objects;
using SharpDX_Engine.Utitities;

namespace SharpDX_Engine_Tutorial.Objects.Ingame
{
    //! This displays a AI behaviour.
    public class Icon : DrawableObject
    {
        int Index;

        public Icon(int Index)
        {
            this.Index = Index;
            Texture = "Icon" + Index + "0";
            Size = new Size(64, 64);
            Position = new Coordinate((Index - 1) * 64, 0);
        }

        public void Activate()
        {
            Texture = "Icon" + Index + "1";
        }

        public void Disable()
        {
            Texture = "Icon" + Index + "0";
        }
    }
}
