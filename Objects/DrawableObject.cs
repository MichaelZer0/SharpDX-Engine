using SharpDX.Direct2D1;

namespace NekuSoul.SharpDX_Engine.Objects
{
    public class Coordinates
    {
        public float X = 0f;
        public float Y = 0f;
        public float width = 0f;
        public float heigth = 0f;

        public Coordinates() { }
        public Coordinates(float X, float Y, float width, float heigth)
        {
            this.X = X;
            this.Y = Y;
            this.width = width;
            this.heigth = heigth;
        }
    }

    public class DrawableObject
    {
        public string Texture;
        public Coordinates Position;

        public DrawableObject()
        {
            Texture = "Default";
            Position = new Coordinates(0f, 0f, 10f, 10f);
        }
    }
}
