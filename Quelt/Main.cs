﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

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

        public static readonly string mainDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Snake", "Snake Game +");

        public static void RunGame()
        {
            if (!Directory.Exists(mainDirectory))
            {
                Directory.CreateDirectory(mainDirectory);
            }

            DataFile dataFile = new DataFile(Path.Combine(mainDirectory, "test.json"));

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
