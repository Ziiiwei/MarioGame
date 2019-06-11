using System;
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
    public class StarMario : Mario
    {
        public IMario mario;
        public IMarioState State { get; set; }
        public IMarioPowerUpState PowerUpState { get; set; }

        public IMarioPowerUpState PreviousPowerUpState { get; set; }
        int timer = 1000;

        public StarMario(IMario mario)
        {
            this.mario = mario;
            this.mario.PowerUpState = new StarMarioState();
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
            // We don't want star mario to power up
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

    }
}
