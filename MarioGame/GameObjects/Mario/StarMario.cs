﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;
using Gamespace.States;

namespace Gamespace
{
    /* This will be changed to implement AbstractGameObject soon. */
    public class StarMario : IMario
    {
        public int Uid { get; }
        public ISprite Sprite { get; set; }
        public IMarioState State { get; set; }
        public Vector2 PositionOnScreen { get; }

        public IMarioPowerUpState PowerUpState { get; set; }
        public IMarioPowerUpState PreviousPowerUpState;
        internal IPhysics Physics { get; set; }


        private IMario mario;
        int timer = 1000;

        public StarMario(IMario mario)
        {
            this.mario = mario;
            this.Uid = mario.Uid;
            this.State = mario.State;
            this.PreviousPowerUpState = this.mario.PowerUpState;
            this.mario.PowerUpState = new StarMarioState();
            if (false)
                this.mario.PowerUpState = new SmallStarMarioState();
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Draw(spriteBatch);

        }

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                this.mario.PowerUpState = this.PreviousPowerUpState;
                this.mario.UpdateArt();
                World.Instance.Mario = this.mario;
            }
            this.mario.Update();
        }

        public void Jump()
        {
           mario.Jump();
        }

        public void MoveRight()
        {
            mario.MoveRight();
        }

        public void MoveLeft()
        {
            mario.MoveLeft();
        }

        public void Crouch()
        {
            mario.Crouch();
        }

        public void PowerDown()
        {
            // Star mario doesn't ever power down
        }

        public void PowerUp()
        {
            this.mario.PowerUpState.PowerUp(this.mario);
        }

        public void UpdateArt()
        {
            mario.UpdateArt();
        }

        public Rectangle GetCollisionBoundary()
        {
           return mario.GetCollisionBoundary();
        }

        public void CollideLeft(Rectangle collisionArea)
        {
            mario.CollideLeft(collisionArea);
        }

        public void CollideRight(Rectangle collisionArea)
        {
            mario.CollideRight(collisionArea);
        }

        public void CollideUp(Rectangle collisionArea)
        {
            mario.CollideUp(collisionArea);
        }
        public void CollideDown(Rectangle collisionArea)
        {
            mario.CollideDown(collisionArea);
        }

        public Vector2 GetCenter()
        {
            return mario.GetCenter();
        }

        public void Bounce()
        {
            Physics.JumpMaxSpeed(Side.Up);
        }
    }
}
