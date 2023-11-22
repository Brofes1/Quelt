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
            renderInstructions.Add(new RenderInstruction(texture,
                new Vector3((location.X + (texture.Bounds.Size.ToVector2() / 2).X) * scale.X, (location.Y + (texture.Bounds.Size.ToVector2() / 2).Y) * scale.Y, location.Z),
                drawRange, rotation, texture.Bounds.Size.ToVector2() / 2, color ?? Color.White, scale));
        }

        public static void QueueText()
        {

        }

        public static void Render()
        {
            Main.graphicsDevice.Clear(Color.Purple);
            Main.spriteBatch.Begin();

            renderInstructions = renderInstructions.OrderBy(o => o.location.Z).ToList();

            foreach (RenderInstruction instruction in renderInstructions)
            {
                if (instruction.drawRange != null)
                {
                    Main.spriteBatch.Draw(instruction.texture, new Vector2(instruction.location.X + (instruction.drawRange.Value.X * instruction.scale.X), 
                                                instruction.location.Y + (instruction.drawRange.Value.Y * instruction.scale.Y)),
                                                instruction.drawRange, instruction.color, (float)instruction.rotation, instruction.origin,
                                                instruction.scale, SpriteEffects.None, 0f);
                }
                else
                {
                    Main.spriteBatch.Draw(instruction.texture, new Vector2(instruction.location.X, instruction.location.Y),
                                                instruction.drawRange, instruction.color, (float)instruction.rotation, instruction.origin,
                                                instruction.scale, SpriteEffects.None, 0f);
                }
            }

            Main.spriteBatch.End();
            renderInstructions.Clear();
        }
    }

    public class RenderInstruction
    {
        public Texture2D texture;
        public Vector3 location;
        public Rectangle? drawRange;
        public double rotation;
        public Vector2 origin;
        public Color color;
        public Vector2 scale;

        public RenderInstruction(Texture2D texture, Vector3 location, Rectangle? drawRange, double rotation, Vector2 origin, Color color, Vector2 scale)
        {
            this.texture = texture;
            this.location = location;
            this.drawRange = drawRange;
            this.rotation = rotation;
            this.origin = origin;
            this.color = color;
            this.scale = scale;
        }
    }
}
