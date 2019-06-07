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
        private Vector2 previousPosition;
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
            previousPosition = position;
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

        public void HorizontalStop()
        {
            // probably have to (pos.x - intersection rectangle)
            position.X = previousPosition.X;

        }

        public void VerticalStop()
        {
            position.Y = previousPosition.Y;
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

            previousPosition.X = position.X;
            previousPosition.Y = position.Y;
            position.X += (int) velocity.X;
            position.Y += (int) velocity.Y;

            if (acceleration.X != 0)
                acceleration.X += (-1 * directionX) * G;

            if (acceleration.Y != 0)
                acceleration.Y += (-1 * directionY) * G;

            if (position.X <= 0)
                position.X = 750;
            else if (position.X >= 750)
                position.X = 0;

            if (position.Y >= 450)
                position.Y = 0;
            else if (position.Y <= 0)
                position.Y = 450;
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
