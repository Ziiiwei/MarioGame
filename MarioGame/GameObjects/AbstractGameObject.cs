/* Using Deferred SpriteSort taken here https://gamedev.stackexchange.com/questions/47796/objects-being-drawn-on-wrong-layers */
using Gamespace.Interfaces;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;

namespace Gamespace
{
    public class AbstractGameObject : IGameObject, ICollidable
    {
        protected static int counter = 0;
        public int Uid { get; protected set; }
        public ISprite Sprite { get; protected set; }
        protected Vector2 positionOnScreen;
        public Vector2 PositionOnScreen  => positionOnScreen;
        public IPhysics GameObjectPhysics { get; set; }
        private readonly static Dictionary<bool, Action<AbstractGameObject>> updateFunctionPointer;
        public bool IsPaused { get; set; }
        public int BlockSpacePosition { get => (int)Math.Min(Numbers.BLOCK_SPACING_SCALE * Numbers.LEVEL1_BLOCK_WIDTH, Math.Max(0, Math.Floor(positionOnScreen.X / Numbers.BLOCK_SPACING_SCALE))); }
        
        /* Higher integers are drawn first */
        public int DrawPriority { get; protected set; }

        static AbstractGameObject()
        {
            updateFunctionPointer = new Dictionary<bool, Action<AbstractGameObject>>()
            {
                {false, new Action<AbstractGameObject>((gameObject) => gameObject.SurrogateUpdate()) },
                {true, new Action<AbstractGameObject>((gameObject) => { }) }
            };
        }

        public AbstractGameObject()
        {
            Uid = counter;
            counter++;
        }

        public AbstractGameObject(Vector2 positionOnScreen)
        {
            SetSprite();
            this.positionOnScreen = positionOnScreen;
            Uid = counter;
            counter++;
            //GameObjectPhysics = new Physics(this, positionOnScreen); 
            GameObjectPhysics = PhysicsFactory.Instance.GetPhysics(this, positionOnScreen);
            IsPaused = false;
            DrawPriority = 0;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, PositionOnScreen);
        }

        public void Update()
        {
            updateFunctionPointer[IsPaused].Invoke(this);
        }

        protected virtual void SurrogateUpdate()
        {
            if (GameObjectPhysics.Velocity.LengthSquared() > 0)
            {
                Sprite.Update();
            }
        }

        public virtual Rectangle GetCollisionBoundary()
        {
            return new Rectangle((int)GameObjectPhysics.Position.X, (int)GameObjectPhysics.Position.Y, Sprite.Width, Sprite.Height);
        }

        public virtual Vector2 GetCenter()
        {
            // this and the camera factor are both 2, and they may be related to the same issue
            float height = Sprite.Height / Numbers.CAMERA_FACTOR;
            float width = Sprite.Width / Numbers.CAMERA_FACTOR;

            return new Vector2(PositionOnScreen.X + width, PositionOnScreen.Y + height);
        }

        protected virtual void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }

        public virtual void CollideLeft(Rectangle collisionArea)
        {
            GameObjectPhysics.LeftStop(collisionArea);
            positionOnScreen = GameObjectPhysics.Position;
        }

        public virtual void CollideRight(Rectangle collisionArea)
        {
            GameObjectPhysics.RightStop(collisionArea);
            positionOnScreen = GameObjectPhysics.Position;
        }

        public virtual void CollideUp(Rectangle collisionArea)
        {
            GameObjectPhysics.UpStop(collisionArea);
            positionOnScreen = GameObjectPhysics.Position;
        }

        public virtual void CollideDown(Rectangle collisionArea)
        {
            GameObjectPhysics.DownStop(collisionArea);
            positionOnScreen = GameObjectPhysics.Position;
        }
    }
}
