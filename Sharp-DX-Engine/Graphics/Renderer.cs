using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine.Utitities;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;

namespace NekuSoul.SharpDX_Engine.Graphics
{
    public class Renderer : RenderHelper
    {
        public RenderTarget _RenderTarget;
        public Color _ClearColor;
        TextureManager _TextureManager;
        public Coordinate Camera;
        private Size Zoom;
        TextFormat DefaultFormat = new TextFormat(new SharpDX.DirectWrite.Factory(), "Calibri", 16) { TextAlignment = TextAlignment.Leading, ParagraphAlignment = ParagraphAlignment.Near, WordWrapping = WordWrapping.NoWrap };

        public Renderer(RenderTarget _RenderTarget, TextureManager _TextureManager)
        {
            Zoom = new Size(1, 1);
            this.Camera = new Coordinate(0,0);
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
                    Utitities.Converter.CreateRectangleF(
                    DrawableObject.Position + Camera,
                    DrawableObject.Size * Zoom),
                    DrawableObject.Transparency,
                    BitmapInterpolationMode.NearestNeighbor
                    );
        }

        public void DrawText(string Text, Coordinate Coordinate)
        {
            _RenderTarget.DrawText(Text, DefaultFormat, Utitities.Converter.CreateRectangleF(Coordinate, new Size()), new SolidColorBrush(_RenderTarget, Color.White));
        }
    }

    public interface RenderHelper
    {
        void DrawObject(DrawableObject DrawableObject);
        void DrawText(string Text, Coordinate Coordinate);
    }
}