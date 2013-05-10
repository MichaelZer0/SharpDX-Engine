namespace NekuSoul.SharpDX_Engine.Utitities
{
    public class Coordinate
    {
        public float X = 0;
        public float Y = 0;

        public Coordinate()
        { }

        public Coordinate(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    public class Size
    {
        public float width = 0;
        public float height = 0;

        public Size()
        { }

        public Size(float width, float height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
