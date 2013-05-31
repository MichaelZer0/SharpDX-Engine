using NekuSoul.SharpDX_Engine.Utitities;

namespace NekuSoul.SharpDX_Engine.Objects
{
    public class Rectangle
    {
        public float X = 0f;
        public float Y = 0f;
        public float width = 0f;
        public float heigth = 0f;

        public Rectangle() { }
        public Rectangle(float X, float Y, float width, float heigth)
        {
            this.X = X;
            this.Y = Y;
            this.width = width;
            this.heigth = heigth;
        }

        public static bool Intersect(Rectangle A, Rectangle B)
        {
            return !((A.X > B.X + B.width || A.X + A.width < B.X) || (A.Y > B.Y + B.heigth || A.Y + A.heigth < B.Y));
        }
    }

    public abstract class DrawableObject
    {
        public string Texture;
        public Coordinate Position;
        public Coordinate Offset;
        public Size Size;
        public float Transparency;

        public DrawableObject()
        {
            Texture = "Default";
            Position = new Coordinate(0f, 0f);
            Offset = new Coordinate(0f, 0f);
            Size = new Size(32f, 32f);
            Transparency = 1f;
        }
    }

    public class SimpleDrawableObject : DrawableObject
    {

    }
}
