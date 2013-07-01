using SharpDX_Engine.Utitities;
using SharpDX_Engine;

namespace SharpDX_Engine.Objects
{

    public abstract class DrawableObject
    {
        public string Texture;
        public Coordinate Position;
        public Coordinate Offset;
        public Size Size;
        public float Transparency;
        public bool CameraAffected;
        public int Frame;
        public int State;

        public DrawableObject()
        {
            Texture = "Default";
            Position = new Coordinate(0f, 0f);
            Offset = new Coordinate(0f, 0f);
            Size = new Size(Game.TextureManager.GetTexture(Texture).Size.Width, Game.TextureManager.GetTexture(Texture).Size.Height);
            Transparency = 1f;
            CameraAffected = true;
            Frame = 1;
            State = 1;
        }

        public DrawableObject(string Texture)
        {
            this.Texture = Texture;
            Position = new Coordinate(0f, 0f);
            Offset = new Coordinate(0f, 0f);
            Size = new Size(Game.TextureManager.GetTexture(Texture).Size.Width, Game.TextureManager.GetTexture(Texture).Size.Height);
            Transparency = 1f;
            CameraAffected = true;
            Frame = 1;
            State = 1;
        }
    }

    public class SimpleDrawableObject : DrawableObject
    {
        public SimpleDrawableObject(string Texture)
        {
            this.Texture = Texture;
            Size = new Size(Game.TextureManager.GetTexture(Texture).Size.Width, Game.TextureManager.GetTexture(Texture).Size.Height);
        }
    }
}
