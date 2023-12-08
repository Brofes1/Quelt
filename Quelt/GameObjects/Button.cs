using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Quelt.GameObjects
{
    public class Button : GameObject
    {
        public event EventHandler<string> LeftPressed;
        public event EventHandler<string> MiddlePressed;
        public event EventHandler<string> RightPressed;

        private Texture2D? _texture = null;

        public Button(GameObject _parent, Vector3 relativeLocation, Rectangle? _hitbox, string externalID) : base(_parent, relativeLocation, _hitbox, externalID) { }

        public Button(GameObject _parent, Vector3 relativeLocation, Rectangle? _hitbox, string externalID, Texture2D texture)
            : base(_parent, relativeLocation, _hitbox, externalID)
        {
            this._texture = texture;
        }

        public override void Update()
        {
            if (InputHandler.objectMouseOver == this)
            {
                if (LeftPressed != null && InputHandler.LeftMouse.justPressed) LeftPressed(this, "");
                if (MiddlePressed != null && InputHandler.MiddleMouse.justPressed) MiddlePressed(this, "");
                if (RightPressed != null && InputHandler.RightMouse.justPressed) RightPressed(this, "");
            }
        }

        public override void Render()
        {
            if (this._texture != null)
                Renderer.QueueTexture(this._texture, this.Location, null, Renderer.noRotation, Color.White, Vector2.One);
        }
    }
}