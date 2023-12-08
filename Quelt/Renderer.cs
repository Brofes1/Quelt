using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quelt
{
    public static class Renderer
    {
        public const double noRotation = 0f;
        public const double cwRotation = Math.PI / 2;
        public const double halfRotation = Math.PI;
        public const double ccwRotation = Math.PI * 3 / 2;

        public static Vector2 topLeft { get { return new Vector2(0, 0); } }
        public static Vector2 topRight { get { return new Vector2(Main.graphicsDevice.Viewport.Width, 0); } }
        public static Vector2 bottomLeft { get { return new Vector2(0, Main.graphicsDevice.Viewport.Height); } }
        public static Vector2 bottomRight { get { return Main.graphicsDevice.Viewport.Bounds.Size.ToVector2(); } }

        public static Vector2 topMiddle { get { return new Vector2(Main.graphicsDevice.Viewport.Width / 2, 0); } }
        public static Vector2 rightMiddle { get { return new Vector2(Main.graphicsDevice.Viewport.Width, Main.graphicsDevice.Viewport.Height / 2); } }
        public static Vector2 bottomMiddle { get { return new Vector2(Main.graphicsDevice.Viewport.Width / 2, Main.graphicsDevice.Viewport.Height); } }
        public static Vector2 leftMiddle { get { return new Vector2(0, Main.graphicsDevice.Viewport.Height / 2); } }
        
        public static Vector2 center { get { return Main.graphicsDevice.Viewport.Bounds.Size.ToVector2() / 2; } }

        static List<RenderInstruction> renderInstructions = new List<RenderInstruction>();

        public static void QueueTexture(Texture2D texture, Vector3 location, Rectangle? drawRange, double rotation, Color? color, Vector2 scale)
        {
            renderInstructions.Add(new TextureInstruction(texture,
                new Vector3((location.X + (texture.Bounds.Size.ToVector2() / 2).X) * scale.X, (location.Y + (texture.Bounds.Size.ToVector2() / 2).Y) * scale.Y, location.Z),
                drawRange, rotation, texture.Bounds.Size.ToVector2() / 2, color ?? Color.White, scale));
        }

        public static void QueueText(SpriteFont spriteFont, StringBuilder stringBuilder, Vector3 location, double rotation, Color? color, float scale)
        {
            renderInstructions.Add(new TextInstruction(spriteFont, stringBuilder, location, 0f, Vector2.Zero, color ?? Color.White, scale));
        }

        public static void Render()
        {
            Main.graphicsDevice.Clear(Color.Purple);
            Main.spriteBatch.Begin();

            renderInstructions = renderInstructions.OrderBy(o => o.location.Z).ToList();

            foreach (RenderInstruction instruction in renderInstructions)
                instruction.Render();

            Main.spriteBatch.End();
            renderInstructions.Clear();
        }
    }

    public class RenderInstruction
    {
        Vector3 location;
        double rotation;
        Vector2 origin;
        Color color;

        internal RenderInstruction(Vector3 location, double rotation, Vector2 origin, Color color)
        {
            this.location = location;
            this.rotation = rotation;
            this.origin = origin;
            this.color = color;
        }

        public abstract void Render() { }
    }

    public class TextureInstruction : RenderInstruction
    {
        Texture2D texture;
        Rectangle? drawRange;
        Vector2 scale;

        public TextureInstruction(Texture2D texture, Vector3 location, Rectangle? drawRange, double rotation, Vector2 origin, Color color, Vector2 scale) : base(location, rotation, origin, color)
        {
            this.texture = texture;
            this.drawRange = drawRange;
            this.scale = scale;
        }

        public override void Render()
        {
            if (this.drawRange != null)
                {
                    Main.spriteBatch.Draw(this.texture, new Vector2(this.location.X + (this.drawRange.Value.X * this.scale.X), 
                                                this.location.Y + (this.drawRange.Value.Y * this.scale.Y)),
                                                this.drawRange, this.color, (float)this.rotation, this.origin,
                                                this.scale, SpriteEffects.None, 0f);
                }
                else
                {
                    Main.spriteBatch.Draw(this.texture, new Vector2(this.location.X, this.location.Y),
                                                this.drawRange, this.color, (float)this.rotation, this.origin,
                                                this.scale, SpriteEffects.None, 0f);
                }
        }
    }

    public class TextInstruction : RenderInstruction
    {
        SpriteFont spriteFont;
        StringBuilder stringBuilder;
        float scale;

        public TextInstruction(SpriteFont spriteFont, StringBuilder stringBuilder, Vector3 location, 
            double rotation, Vector2 origin, Color color, float scale) : base(location, rotation, origin, scale)
        {
            this.spriteFont = spriteFont;
            this.stringBuilder = stringBuilder;
            this.location = location;
        }

        public override void Render()
        {
            Main.spriteBatch.DrawString(this.spriteFont, this.stringBuilder, new Vector2(this.location.X, this.location.Y), 
                this.color, (float)this.rotation, this.origin, new Vector2(this.scale), SpriteEffects.None, 0f, false);
        }
    }
}
