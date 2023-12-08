using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Quelt
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ContentHandler.LoadTextures(Content);

            Text test = new Text(Main.rootGameObject, new Vector3(50, 50, 25), ContentHandler.testFont, TextSnap.topLeft, "This is a <C:#00ff00>green</C> word!\\nHere's a newline, too!", 60, null);

            int i = 1;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputHandler.UpdateInput();

            foreach (GameObject gameObject in Main.gameObjectList)
                gameObject.Update();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Renderer.Render();

            foreach (GameObject gameObject in Main.gameObjectList)
                gameObject.Render();

            base.Draw(gameTime);
        }
    }
}