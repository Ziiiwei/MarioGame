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

        private float maxSpeed_pf = 2f; //pix per frame
        private float jumpSpeed_pf = 3f; //pix per frame
        // Invariant: G < A
        public const float G = 0.2f; //the G of the marioward 
        public const float A = 0.8f; //
        // public const float DefaultAccelerationTime = (float)0.5;


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

        public void Stop()
        {
            acceleration.X *= -1;
            acceleration.Y *= -1;
        }

        public void Update()
        {
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
            
            position.X += velocity.X;
            position.Y += velocity.Y;

            if (acceleration.X != 0)
                acceleration.X += (-1 * directionX) * G;

            if (acceleration.Y != 0)
                acceleration.Y += (-1 * directionY) * G;

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
    }
}
