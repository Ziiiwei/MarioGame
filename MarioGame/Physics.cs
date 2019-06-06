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

        private float maxSpeed_pf = 3f; //pix per frame
        private float jumpSpeed_pf = 3f; //pix per frame
        public const float G = 0.2f; //the G of the marioward 
        public const float A = 0.1f; //horizontal sccelaration
        // public const float DefaultAccelerationTime = (float)0.5;


        public Physics(IGameObject gameObject,Vector2 position)
        {
            this.gameObject = gameObject;
            this.position = position;
          

            this.Stop();
        }
        public void FreeFall()
        {
            acceleration.Y = G;
        }

        public void Jump()
        {
            velocity.Y = (float)-jumpSpeed_pf;
            acceleration.Y = G;
        }

        public void MoveLeft()
        {
            acceleration.X = -A;
        }

        public void MoveRight()
        {
            
            acceleration.X = A;
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
            velocity = new Vector2(0, 0);
            acceleration = new Vector2(0, 0);
        }

        public void Update()
        {
            if (Math.Abs(velocity.X) < maxSpeed_pf || Math.Abs(velocity.X+acceleration.X)< maxSpeed_pf)
            {
                velocity.X += acceleration.X;
            }

            velocity.Y += acceleration.Y;

            position.X += velocity.X;
            position.Y += velocity.Y;

        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
