using NekuSoul.SharpDX_Engine.Objects;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace NekuSoul.SharpDX_Engine.Utitities
{
    class Converter
    {
        public static Matrix3x2 SizeToMatrix(float xStretch, float yStretch)
        {
            return new Matrix3x2(xStretch, 0f, 0f, yStretch, 0f, 0f);
        }

        public static RectangleF CoordinatesToRectangleF(Coordinates _Coordinates)
        {
            return new RectangleF((int)_Coordinates.X, (int)_Coordinates.Y, (int)_Coordinates.X + (int)_Coordinates.width, (int)_Coordinates.Y + (int)_Coordinates.heigth);
        }

        public static BitmapBrush BitmapToBitmapBrush(RenderTarget _RenderTarget, Bitmap _Bitmap)
        {
            return new BitmapBrush(_RenderTarget, _Bitmap);
        }
    }
}
