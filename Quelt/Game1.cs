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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputHandler.UpdateInput();

            Main.gameObjects = Main.gameObjects.OrderBy(gameObject => -gameObject.Location.Z).ToList();

            foreach (GameObject gameObject in Main.gameObjects)
                gameObject.Update();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Renderer.Render();

            foreach (GameObject gameObject in Main.gameObjects)
                gameObject.Render();

            base.Draw(gameTime);
        }
    }
}