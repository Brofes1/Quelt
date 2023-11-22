using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputHandler.UpdateInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Renderer.QueueTexture(ContentHandler.testImage, new Vector3(100, 100, 5), new Rectangle(10, 0, 40, 60), Renderer.noRotation, null, new Vector2(1, 1));
            Renderer.QueueTexture(ContentHandler.testImage, new Vector3(100, 160, 5), null, Renderer.noRotation, null, new Vector2(1, 1));
            if (InputHandler.A.justReleased)
            {
                Renderer.QueueTexture(ContentHandler.testImage, new Vector3(100, 220, 5), null, Renderer.ccwRotation, null, Vector2.One);
            }

            Renderer.Render();

            base.Draw(gameTime);
        }
    }
}