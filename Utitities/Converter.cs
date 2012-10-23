using SharpDX;
using SharpDX.Direct2D1;

namespace NekuSoul.SharpDX_Engine.Utitities
{
    class Converter
    {
        public static Matrix3x2 SizeToMatrix(float xStretch, float yStretch)
        {
            return new Matrix3x2(xStretch, 0f, 0f, yStretch, 0f, 0f);
        }

        public static RectangleF RectangleToRectangleF(NekuSoul.SharpDX_Engine.Objects.Rectangle _Coordinates)
        {
            return new RectangleF(_Coordinates.X, _Coordinates.Y, _Coordinates.X + _Coordinates.width, _Coordinates.Y + _Coordinates.heigth);
        }

        public static BitmapBrush BitmapToBitmapBrush(RenderTarget _RenderTarget, Bitmap _Bitmap)
        {
            return new BitmapBrush(_RenderTarget, _Bitmap);
        }
    }
}
