using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace 
{
    public class Physics : IPhysics
    {
    
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 acceleration;
        public IGameObject gameObject { get; set; }

        //default acceleration for left and right move

        private float maxSpeed_pf = MarioWorldConstant.MARIO_MAX_V; //pix per frame
        private float jumpSpeed_pf = MarioWorldConstant.MARIO_JUMP_V; //pix per frame
        // Invariant: G < A
        public const float G = MarioWorldConstant.G; //the G of the marioward 
        public const float A = MarioWorldConstant.MARIO_A; //the default movement A
       


        public Physics(IGameObject gameObject,Vector2 position)
        {
            this.gameObject = gameObject;
            this.position = position;
        
            acceleration = new Vector2(0, 0);
            velocity = new Vector2(0, 0);
        }
        public void FreeFall()
        {
            acceleration.Y = G;
        }

        public void Jump()
        {
            acceleration.Y = -A;
        }

        public void MoveUp()
        {
            acceleration.Y = -A;
        }

        public void MoveLeft()
        {
            acceleration.X = -A;
        }

        public void MoveRight()
        {
            
            acceleration.X = A;
        }

        public void MoveDown()
        {
            acceleration.Y = A;
        }

        public void SlowDown()
        {
            //nothing yet
        }

        public void SpeedUp()
        {
            //nothing yet
        }

        public void LeftStop(Rectangle collisionArea)
        {
            position.X = position.X + collisionArea.Width;
        }

        public void RightStop(Rectangle collisionArea)
        {
            position.X = position.X - collisionArea.Width;

        }

        public void UpStop(Rectangle collisionArea)
        {
            position.Y = position.Y + collisionArea.Height;
        }

        public void DownStop(Rectangle collisionArea)
        {
            position.Y = position.Y - collisionArea.Height;
        }

        public void Update()
        {
           

            int directionX = 1;
            int directionY = 1;

            if (velocity.X < 0)
            {
                directionX = -1;
            }
            if (velocity.Y < 0)
            {
                directionY = -1;
            }
            
            velocity.X = MinimumMagnitude(velocity.X + acceleration.X, directionX * maxSpeed_pf);
            velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, directionY * maxSpeed_pf);


            position.X += (int) velocity.X;
            position.Y += (int) velocity.Y;


            if (!(velocity.X == 0) && Math.Sign(velocity.X) != Math.Sign(velocity.X + acceleration.X))
            {
                velocity.X = 0;
                acceleration.X = 0;
            }

            if (!(velocity.Y == 0) && Math.Sign(velocity.Y) != Math.Sign(velocity.Y + acceleration.Y))
            {
                velocity.Y = 0;
                acceleration.Y = 0;
            }

            if (acceleration.X != 0)
                acceleration.X += (-1 * directionX) * G;

            if (acceleration.Y != 0)
                acceleration.Y += (-1 * directionY) * G;

            loop();
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        /* Will return the signed integer which has the least magnitude */
        private float MinimumMagnitude(float a, float b)
        {
            return Math.Abs(a) < Math.Abs(b) ? a : b;
        }

        private void loop()
        {

            if (position.X <= 0)
                position.X = MarioWorldConstant.GAME_WINDOW_WIDTH / MarioWorldConstant.SCALE;
            else if (position.X >= MarioWorldConstant.GAME_WINDOW_WIDTH / MarioWorldConstant.SCALE)
                position.X = 0;

            if (position.Y >= MarioWorldConstant.GAME_WINDOW_HEIGHT / MarioWorldConstant.SCALE)
                position.Y = 0;
            else if (position.Y <= 0)
                position.Y = MarioWorldConstant.GAME_WINDOW_HEIGHT / MarioWorldConstant.SCALE;
        }
    }
}
