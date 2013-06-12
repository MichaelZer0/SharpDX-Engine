using SharpDX_Engine.Utitities;
using SharpDX_Engine;

namespace SharpDX_Engine.Objects
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
        public bool CameraAffected;
        public int FrameCount;
        //x private Rectangle Rectangle;

        public DrawableObject()
        {
            Texture = "Default";
            Position = new Coordinate(0f, 0f);
            Offset = new Coordinate(0f, 0f);
            Size = new Size(Game.TextureManager.GetTexture(Texture).Size.Width, Game.TextureManager.GetTexture(Texture).Size.Height);
            Transparency = 1f;
            CameraAffected = true;
            FrameCount = 1;
        }
    }

    public class SimpleDrawableObject : DrawableObject
    {
        public SimpleDrawableObject(string Texture)
        {
            this.Texture = Texture;
            Size = new Size(Game.TextureManager.GetTexture(Texture).Size.Width, Game.TextureManager.GetTexture(Texture).Size.Height);
        }
    }
}
