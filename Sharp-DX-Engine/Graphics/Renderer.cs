using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine.Utitities;
using SharpDX;
using SharpDX.Direct2D1;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine.Graphics
{
    public class Renderer : RenderHelper
    {
        public RenderTarget _RenderTarget;
        public Color _ClearColor;
        TextureManager _TextureManager;
        private Coordinate Camera;
        private Size Zoom;

        public Renderer(RenderTarget _RenderTarget, TextureManager _TextureManager, Coordinate Camera)
        {
            Zoom = new Size(1, 1);
            this.Camera = Camera;
            this._RenderTarget = _RenderTarget;
            this._TextureManager = _TextureManager;
            _RenderTarget.AntialiasMode = AntialiasMode.Aliased;
        }

        public void Draw(Scene ActiveScene)
        {
            _RenderTarget.BeginDraw();
            _RenderTarget.Clear(_ClearColor);
            ActiveScene.Draw(this);
            _RenderTarget.EndDraw();
        }

        public void Clear()
        {
            _RenderTarget.BeginDraw();
            _RenderTarget.Clear(_ClearColor);
            _RenderTarget.EndDraw();
        }

        public void DrawObject(DrawableObject DrawableObject)
        {
            _RenderTarget.DrawBitmap(
                _TextureManager.GetTexture(DrawableObject.Texture),
                    Utitities.Converter.CreateRectangleF(DrawableObject.Position + Camera, DrawableObject.Size * Zoom),
                    1f,
                    BitmapInterpolationMode.NearestNeighbor
                    );
        }
    }

    public interface RenderHelper
    {
        void DrawObject(DrawableObject DrawableObject);
    }
}