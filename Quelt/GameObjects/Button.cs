namespace Quelt
{
    public class Button : GameObject
    {
        public event EventHandler<Button> LeftPressed;
        public event EventHandler<Button> MiddlePressed;
        public event EventHandler<Button> RightPressed;

        private Texture2D? _texture = null;

        public Button(GameObject _parent, Vector3 relativeLocation, Vector2? _hitboxSize, string externalID) : base(_parent, relativeLocation, _hitboxSize, externalID) { }

        public Button(GameObject _parent, Vector3 relativeLocation, Vector2? _hitboxSize, string externalID, Texture2D texture)
            : base(_parent, relativeLocation, _hitboxSize, externalID)
        {
            this._texture = texture;
        }

        public override void Update()
        {
            if (InputHandler.objectMouseOver == this)
            {
                if (LeftPressed != null && InputHandler.LeftMouse.justPressed) LeftPressed(this);
                if (MiddlePressed != null && InputHandler.MiddleMouse.justPressed) MiddleMouse(this);
                if (RightPressed != null && InputHandler.RightMouse.justPressed) RightMouse(this);
            }
        }

        public override void Render()
        {

        }
    }
}