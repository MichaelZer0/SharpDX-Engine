using NekuSoul.SharpDX_Engine.Objects;
using SharpDX;
using SharpDX.Direct2D1;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine.Graphics
{
    public class Renderer
    {
        public RenderTarget _RenderTarget;
        public Color _ClearColor;
        TextureManager _TextureManager;

        public Renderer(RenderTarget _RenderTarget, TextureManager _TextureManager)
        {
            this._RenderTarget = _RenderTarget;
            this._TextureManager = _TextureManager;
            _RenderTarget.AntialiasMode = AntialiasMode.Aliased;
        }

        public void Draw(List<DrawableObject> DrawList)
        {
            _RenderTarget.BeginDraw();
            foreach (DrawableObject _DrawableObject in DrawList)
            {
                _RenderTarget.DrawBitmap(
                _TextureManager.GetTexture(_DrawableObject.Texture),
                    Utitities.Converter.RectangleToRectangleF(_DrawableObject.Position),
                    1f,
                    BitmapInterpolationMode.NearestNeighbor
                    );
            }
            _RenderTarget.EndDraw();
        }

        public void Clear()
        {
            _RenderTarget.BeginDraw();
            _RenderTarget.Clear(_ClearColor);
            _RenderTarget.EndDraw();
        }
    }
}
