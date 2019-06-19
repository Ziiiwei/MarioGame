﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;
using Gamespace.States;
using Gamespace.Interfaces;

namespace Gamespace
{
    /*
    public class Mario : IMario, ICollidable
    {
        public int Uid { get; }
        public ISprite Sprite { get; set; }
        public IMarioState State { get; set; }
        public IMarioPowerUpState PowerUpState { get; set; }
        public IPhysics Physics { get; protected set; }
        public Vector2 PositionOnScreen { get; private set; }

        private delegate void PhysicUpdate();
        private PhysicUpdate physicUpdate;

        public Mario(Vector2 positionOnScreen)
        {
            State = new RightStandingMarioState(this);
            PowerUpState = new MarioSmallState();
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, PowerUpState.GetType().Name);
            Physics = new Physics(this, positionOnScreen);
            Uid = -1;

            
            physicUpdate = () => {
                Physics.FreeFall();
                Physics.Update();
                Physics.Stop();
            };
            
    }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, PositionOnScreen);
        }

        public void Update()
        {
            Sprite.Update();
            //physicUpdate();
            Physics.Update();
            PositionOnScreen = Physics.GetPosition();
              
        }

        public void Jump()
        {
            State.Jump();
            Physics.MoveUp();
        }

        public void MoveRight()
        {
            State.MoveRight();
            Physics.MoveRight();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
            Physics.MoveLeft();
        }

        public void Crouch()
        {
            State.Crouch();
            Physics.MoveDown();
        }

        public void PowerDown()
        {
            PowerUpState.PowerDown(this);
            UpdateArt();
        }

        public void PowerUp()
        {
            PowerUpState.PowerUp(this);
            UpdateArt();
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, PowerUpState.GetType().Name);
        }

        public Rectangle GetCollisionBoundary()
        {
            return new Rectangle((int)PositionOnScreen.X, (int)PositionOnScreen.Y, Sprite.Width, Sprite.Height);
        }

        public void CollideLeft(Rectangle collisionArea)
        {
            Physics.LeftStop(collisionArea);
            PositionOnScreen = Physics.GetPosition();
        }

        public void CollideRight(Rectangle collisionArea)
        {
            Physics.RightStop(collisionArea);
            PositionOnScreen = Physics.GetPosition();
        }

        public void CollideUp(Rectangle collisionArea)
        {
            Physics.UpStop(collisionArea);
            PositionOnScreen = Physics.GetPosition();
        }
        public void CollideDown(Rectangle collisionArea)
        {
            Physics.DownStop(collisionArea);
            PositionOnScreen = Physics.GetPosition();
        }

        public Vector2 GetCenter()
        {
            float height = Sprite.Height / 2;
            float width = Sprite.Width / 2;

            return new Vector2(PositionOnScreen.X + width, PositionOnScreen.Y + height);
        }

    }
    */
}