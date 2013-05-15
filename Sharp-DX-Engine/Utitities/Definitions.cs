using NekuSoul.SharpDX_Engine.Objects;

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

        public static Coordinate operator +(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.X + c2.X, c1.Y + c2.Y);
        }

        public bool IsWithinRectangle(Rectangle Rectangle)
        {
            if ((X > Rectangle.Coordinate.X && Y > Rectangle.Coordinate.Y) && (X < Rectangle.Coordinate.X + Rectangle.Size.width && Y < Rectangle.Coordinate.Y + Rectangle.Size.height))
            {
                return true;
            }
            return false;
        }

        public bool IsWithinDrawableObject(DrawableObject DrawableObject)
        {
            return IsWithinRectangle(new Rectangle(DrawableObject.Position, DrawableObject.Size));
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

        public static Size operator +(Size c1, Size c2)
        {
            return new Size(c1.width + c2.width, c1.height + c2.height);
        }

        public static Size operator +(Size c1, float c2)
        {
            return new Size(c1.width + c2, c1.height + c2);
        }

        public static Size operator *(Size c1, Size c2)
        {
            return new Size(c1.width * c2.width, c1.height * c2.height);
        }

        public static Size operator *(Size c1, float c2)
        {
            return new Size(c1.width * c2, c1.height * c2);
        }
    }

    public class Rectangle
    {
        public Coordinate Coordinate = new Coordinate();
        public Size Size = new Size();

        public Rectangle()
        { }

        public Rectangle(Coordinate Coordinate, Size Size)
        {
            this.Coordinate = Coordinate;
            this.Size = Size;
        }
    }
}
