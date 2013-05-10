using NekuSoul.SharpDX_Engine.Objects;
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

        public static RectangleF DrawableObjecttoRectangleF(DrawableObject DrawableObject)
        {
            return new RectangleF(DrawableObject.Position.X, DrawableObject.Position.Y, DrawableObject.Position.X + DrawableObject.Size.width, DrawableObject.Position.Y + DrawableObject.Size.height);
        }

        public static BitmapBrush BitmapToBitmapBrush(RenderTarget _RenderTarget, Bitmap _Bitmap)
        {
            return new BitmapBrush(_RenderTarget, _Bitmap);
        }
    }
}
