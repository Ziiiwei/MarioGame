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

        public int DefaultAcceleration { get; set; } //default acceleration for left and right move

        private int maxSpeed_pf; //pix per frame
        private int jumpSpeed_pf; //pix per frame
        public const int G = 1; //the G of the marioward 
        public const float DefaultAccelerationTime = (float)0.5;


        public Physics(IGameObject gameObject,Vector2 position, int maxspeed, int jumpspeed,int framerate)
        {
            this.gameObject = gameObject;
            this.position = position;

            maxSpeed_pf = maxspeed / framerate;
            jumpSpeed_pf = jumpspeed / framerate;
            DefaultAcceleration = (int)(maxspeed / (framerate*DefaultAccelerationTime));

            this.Stop();
        }
        public void FreeFall()
        {
            acceleration.Y = G;
        }

        public void Jump()
        {
            velocity.Y = -jumpSpeed_pf;
            acceleration.Y = G;
        }

        public void MoveLeft()
        {
            velocity.X = 0;
            acceleration.X = -DefaultAcceleration;
        }

        public void MoveRight()
        {
            velocity.X = 0;
            acceleration.X = -DefaultAcceleration;
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
            if (Math.Abs(velocity.X) < maxSpeed_pf)
            {
                velocity.X += acceleration.X;
            } else
            {
                velocity.X *= (velocity.X / maxSpeed_pf);
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
