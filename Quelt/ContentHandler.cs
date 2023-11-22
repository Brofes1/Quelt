using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Quelt
{
    public static class ContentHandler
    {
        public static Texture2D testImage;

        public static void LoadTextures(ContentManager Content)
        {
            testImage = Content.Load<Texture2D>("Top Bar");
        }
        //public static DirectoryInfo textureDirectory = new DirectoryInfo(Environment.CurrentDirectory);
    }
}
