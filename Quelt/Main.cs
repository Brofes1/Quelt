using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Quelt
{
    public static class Main
    {
        static Game1 _game;

        public static SpriteBatch spriteBatch { get { return _game._spriteBatch; } }
        public static GraphicsDevice graphicsDevice { get { return _game.GraphicsDevice; } }

        public static GameObject rootGameObject;
        public static List<GameObject> gameObjects = new List<GameObject>();

        public static GameObject? overridingGameObject;

        public static void RunGame()
        {
            rootGameObject = GameObject.CreateBaseGameObject();
            _game = new Game1();
            _game.Run();
        }

        public static void RemoveGameObject(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }
    }
}
