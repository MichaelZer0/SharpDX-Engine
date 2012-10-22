using SharpDX.Direct2D1;

namespace NekuSoul.SharpDX_Engine.Objects
{
    public class Coordinates
    {
        float X = 0f;
        float Y = 0f;
    }

    public class DrawableObject
    {
        Bitmap Texture;
        Coordinates Position;

        public DrawableObject(RenderTarget RT)
        {
            Texture = Utitities.Converter.LoadFromFile(RT, "Smiley.bmp");
        }
    }
}
