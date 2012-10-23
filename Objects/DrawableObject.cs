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
    }

    public abstract class DrawableObject
    {
        public string Texture;
        public Rectangle Position;

        public abstract void Update();

        //public DrawableObject()
        //{
        //    Texture = "Default";
        //    Position = new Rectangle(0f, 0f, 10f, 10f);
        //}
    }
}
