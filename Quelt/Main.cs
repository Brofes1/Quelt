using Microsoft.Xna.Framework.Graphics;

namespace Quelt
{
    public static class Main
    {
        static Game1 _game;

        public static SpriteBatch spriteBatch { get { return _game._spriteBatch; } }
        public static GraphicsDevice graphicsDevice { get { return _game.GraphicsDevice; } }

        public static void RunGame()
        {
            _game = new Game1();
            _game.Run();
        }
    }
}
