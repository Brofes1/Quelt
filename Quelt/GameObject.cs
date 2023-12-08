using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Quelt
{
    public class GameObject
    {
        private static uint _currentID = 0;
        private static bool _baseGameObjectCreated = false;
        
        private readonly GameObject? _parent;
        private Rectangle _hitbox;

        public readonly uint internalID;
        public readonly string externalID;
        public Vector3 relativeLocation;

        public Vector3 Location
        {
            get
            {
                if (this._parent == null) return this.relativeLocation;
                else return relativeLocation + this._parent.Location;
            }
        }

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)this.Location.X + this._hitbox.Left, (int)this.Location.Y + this._hitbox.Top,
                    (int)this._hitbox.Size.ToVector2().X, (int)this._hitbox.Size.ToVector2().Y);
            }
        }

        public virtual void Render() { }

        public virtual void Update() { }

        private GameObject()
        {
            this._parent = null;
            this.relativeLocation = new Vector3(0, 0, 0);
            this.externalID = "";
            this.internalID = _currentID++;
            Main.gameObjectList.Add(this);
        }

        public GameObject(GameObject _parent) : this(_parent, new Vector3(0, 0, 0), new Rectangle(0, 0, 0, 0), "") { }
        public GameObject(GameObject _parent, string externalID) : this(_parent, new Vector3(0, 0, 0), new Rectangle(0, 0, 0, 0), externalID) { }
        public GameObject(GameObject _parent, Vector3 relativeLocation) : this(_parent, relativeLocation, new Rectangle(0, 0, 0, 0), "") { }
        public GameObject(GameObject _parent, Vector3 relativeLocation, string externalID) : this(_parent, relativeLocation, new Rectangle(0, 0, 0, 0), externalID) { }
        public GameObject(GameObject _parent, Vector3 relativeLocation, Rectangle? _hitbox) : this(_parent, relativeLocation, _hitbox, "") { }

        public GameObject(GameObject _parent, Vector3 relativeLocation, Rectangle? _hitbox, string externalID)
        {
            this._parent = _parent;
            this.relativeLocation = relativeLocation;
            this.externalID = externalID;
            this.internalID = _currentID++;
            this._hitbox = _hitbox ?? new Rectangle(0, 0, 0, 0);

            if (externalID != "")
                Main.gameObjects.Add(externalID, this);

            Main.gameObjectList.Add(this);
        }

        public static GameObject CreateBaseGameObject()
        {
            if (_baseGameObjectCreated)
                throw new System.Exception("Cannot create more than one base game object; what are you even doing?");

            _baseGameObjectCreated = true;
            return new GameObject();
        }
    }
}
