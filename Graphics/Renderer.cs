using NekuSoul.SharpDX_Engine.Objects;
using SharpDX;
using SharpDX.Direct2D1;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine.Graphics
{
    class Renderer
    {
        RenderTarget _RenderTarget;
        TextureManager _TextureManager;

        public Renderer(RenderTarget _RenderTarget, TextureManager _TextureManager)
        {
            this._RenderTarget = _RenderTarget;
            this._TextureManager = _TextureManager;
        }

        public void Draw(List<DrawableObject> DrawList)
        {
            _RenderTarget.BeginDraw();
            _RenderTarget.Clear(Color.Black);
            foreach (DrawableObject _DrawableObject in DrawList)
            {
                _RenderTarget.FillRectangle(
                    Utitities.Converter.CoordinatesToRectangleF(_DrawableObject.Position),
                    Utitities.Converter.BitmapToBitmapBrush(_RenderTarget, _TextureManager.GetTexture(_DrawableObject.Texture)));
            }
            _RenderTarget.EndDraw();
        }
    }
}
