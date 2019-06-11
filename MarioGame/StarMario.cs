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
    public class StarMario
    {
        IMario mario;
        int timer = 1000;

        public StarMario(IMario mario)
        {
            this.mario = mario;
            this.mario.PowerUpState = new StarMarioState();
        }
        

        public void Draw(SpriteBatch spriteBatch)
        {
            // mario.draw

        }

        public void Update()
        {
            timer--;
            if (timer == 0)
                Game1Singleton.Instance.mario = mario;
            //mario.update

        }

        public void Jump()
        {
           //mario.jump
        }

        public void MoveRight()
        {
            //mario.MoveRight
        }

        public void MoveLeft()
        {
            //mario.Moveleft
        }

        public void Crouch()
        {
            //mario.Crouch
        }

        public void PowerDown()
        {
            // Star mario doesn't ever power down
        }

        public void PowerUp()
        {
            // we don't want star mario to power up
        }

        public void UpdateArt()
        {
            //mario.update art
        }

        public Rectangle GetCollisionBoundary()
        {
            // mario.getcollisionboundary
        }

        public void CollideLeft(Rectangle collisionArea)
        {
            //mario.collideLeft
        }

        public void CollideRight(Rectangle collisionArea)
        {
            //mario.collideRight
        }

        public void CollideUp(Rectangle collisionArea)
        {
            //mario.collideUP
        }
        public void CollideDown(Rectangle collisionArea)
        {
            //mario.collideDOwn
        }

        public Vector2 GetCenter()
        {
            //mario.GetCenter
        }

    }
}
