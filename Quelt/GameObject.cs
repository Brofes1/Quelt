using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Quelt
{
    public class GameObject
    {
        private static int currentID = 0;

        private readonly GameObject? parent;

        public readonly int internalID;
        public readonly string externalID;
        public Vector2? hitboxSize;
        public Vector3 relativeLocation = new Vector3();
        public Vector3 Location
        {
            get
            {
                if (parent == null) return this.relativeLocation;
                else return relativeLocation + parent.Location;
            }
        }

        public virtual void Render() { }

        public virtual void Update() { }

        public virtual void OnClick() { }

        private GameObject()
        {
            this.parent = null;
            this.relativeLocation = new Vector3(0, 0, 0);
            this.externalID = "";
            this.internalID = currentID++;
            Main.gameObjects.Add(this);
        }

        public GameObject(GameObject parent) : this(parent, new Vector3(0, 0, 0), new Vector2(0, 0), "") { }
        public GameObject(GameObject parent, string externalID) : this(parent, new Vector3(0, 0, 0), new Vector2(0, 0), externalID) { }
        public GameObject(GameObject parent, Vector3 relativeLocation) : this(parent, relativeLocation, new Vector2(0, 0), "") { }
        public GameObject(GameObject parent, Vector3 relativeLocation, string externalID) : this(parent, relativeLocation, new Vector2(0, 0), externalID) { }
        public GameObject(GameObject parent, Vector3 relativeLocation, Vector2 hitboxSize) : this(parent, relativeLocation, hitboxSize, "") { }

        public GameObject(GameObject parent, Vector3 relativeLocation, Vector2 hitboxSize, string externalID)
        {
            this.parent = parent;
            this.relativeLocation = relativeLocation;
            this.externalID = externalID;
            this.internalID = currentID++;
            this.hitboxSize = hitboxSize;
            Main.gameObjects.Add(this);
        }

        public static GameObject CreateBaseGameObject()
        {
            return new GameObject();
        }
    }
}
