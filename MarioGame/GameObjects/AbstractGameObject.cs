﻿using Gamespace.Interfaces;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class AbstractGameObject : IGameObject, ICollidable
    {
        protected static int counter = 0;
        public int Uid { get; protected set; }
        public ISprite Sprite { get; protected set; }
        protected Vector2 positionOnScreen;
        public Vector2 PositionOnScreen  => positionOnScreen;

        internal IPhysics GameObjectPhysics { get; set; }
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
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            Sprite.Draw(spriteBatch, PositionOnScreen);
        }

        public virtual void Update()
        {
            Sprite.Update();
        }

        public Rectangle GetCollisionBoundary()
        {
            return new Rectangle((int)GameObjectPhysics.Position.X, (int)GameObjectPhysics.Position.Y, Sprite.Width, Sprite.Height);
        }

        public Vector2 GetCenter()
        {
            float height = Sprite.Height / 2;
            float width = Sprite.Width / 2;

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