using SharpDX_Engine.Objects;
using SharpDX_Engine.Utitities;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;

namespace SharpDX_Engine.Graphics
{
    public class Renderer : RenderHelper
    {
        public RenderTarget _RenderTarget;
        public Color _ClearColor;
        public Coordinate Camera;
        private Coordinate EmptyCoordinate;
        private Size Zoom;
        TextFormat DefaultFormat = new TextFormat(new SharpDX.DirectWrite.Factory(), "Calibri", 16) { TextAlignment = TextAlignment.Leading, ParagraphAlignment = ParagraphAlignment.Near, WordWrapping = WordWrapping.NoWrap };

        public Renderer(RenderTarget _RenderTarget)
        {
            Zoom = new Size(1, 1);
            this.Camera = new Coordinate(0, 0);
            this._RenderTarget = _RenderTarget;
            _RenderTarget.AntialiasMode = AntialiasMode.Aliased;
            _ClearColor = Color.Black;
            EmptyCoordinate = new Coordinate(0, 0);
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
            if (DrawableObject != null)
            {
                _RenderTarget.DrawBitmap(
                   Game.TextureManager.GetTexture(DrawableObject.Texture),
                       Utitities.Converter.CreateRectangleF(
                       DrawableObject.Position + DrawableObject.Offset + (DrawableObject.CameraAffected ? Camera : EmptyCoordinate),
                       DrawableObject.Size * Zoom),
                       DrawableObject.Transparency,
                       BitmapInterpolationMode.NearestNeighbor,
                       new RectangleF((DrawableObject.Frame - 1) * DrawableObject.Size.width, (DrawableObject.State - 1) * DrawableObject.Size.height, (DrawableObject.Frame) * DrawableObject.Size.width, (DrawableObject.State) * DrawableObject.Size.height)
                       );
            }
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