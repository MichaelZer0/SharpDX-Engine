using SharpDX;
using SharpDX.Direct2D1;

namespace SharpDX_Engine.Utitities
{
    class Converter
    {
        internal static Matrix3x2 SizeToMatrix(float xStretch, float yStretch)
        {
            return new Matrix3x2(xStretch, 0f, 0f, yStretch, 0f, 0f);
        }

        internal static RectangleF CreateRectangleF(Coordinate Position, Size Size)
        {
            return new RectangleF(Position.X, Position.Y, Position.X + Size.width, Position.Y + Size.height);
        }

        internal static BitmapBrush BitmapToBitmapBrush(RenderTarget _RenderTarget, Bitmap _Bitmap)
        {
            return new BitmapBrush(_RenderTarget, _Bitmap);
        }
    }
}
