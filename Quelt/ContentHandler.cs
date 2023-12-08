using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Quelt
{
    public static class ContentHandler
    {
        public static SpriteFont testFont;

        public static void LoadTextures(ContentManager Content)
        {
            testFont = Content.Load<SpriteFont>("Arial12");
        }
    }
}
