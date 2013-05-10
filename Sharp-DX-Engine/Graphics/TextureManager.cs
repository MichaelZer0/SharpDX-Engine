using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine.Graphics
{
    public class TextureManager
    {
        Dictionary<string, Bitmap> TextureList = new Dictionary<string, Bitmap>();
        RenderTarget _RenderTarget;

        public TextureManager(RenderTarget _RenderTarget)
        {
            this._RenderTarget = _RenderTarget;
            TextureList.Add("Default", LoadFromFile("Default"));
        }

        public Bitmap GetTexture(string TextureName)
        {
            if (!TextureList.ContainsKey(TextureName))
            {
                try
                {
                    TextureList.Add(TextureName, LoadFromFile(TextureName));
                }
                catch
                {
                    TextureList.Add(TextureName, TextureList["Default"]);
                }
            }
            return TextureList[TextureName];
        }

        private Bitmap LoadFromFile(string file)
        {
            // Loads from file using System.Drawing.Image
            using (var bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile("Ressources\\" + file + ".png"))
            {
                var sourceArea = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var bitmapProperties = new BitmapProperties(new SharpDX.Direct2D1.PixelFormat(Format.R8G8B8A8_UNorm, AlphaMode.Premultiplied));
                var size = new DrawingSize(bitmap.Width, bitmap.Height);

                // Transform pixels from BGRA to RGBA
                int stride = bitmap.Width * sizeof(int);
                using (var tempStream = new DataStream(bitmap.Height * stride, true, true))
                {
                    // Lock System.Drawing.Bitmap
                    var bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                    // Convert all pixels 
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        int offset = bitmapData.Stride * y;
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            // Not optimized 
                            byte B = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte G = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte R = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte A = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            int rgba = R | (G << 8) | (B << 16) | (A << 24);
                            tempStream.Write(rgba);
                        }

                    }
                    bitmap.UnlockBits(bitmapData);
                    tempStream.Position = 0;

                    return new Bitmap(_RenderTarget, size, tempStream, stride, bitmapProperties);
                }
            }
        }
    }
}
