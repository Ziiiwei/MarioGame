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

        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration;
        public IGameObject gameObject { get; set; }

        private float GRAVITY;
        private float FORCE_HORIZONTAL_AGAINST;
        private float GAMEOBJECT_FORCE_UP;
        private float GAMEOBJECT_FORCE_HORIZONTAL;
        private float MAX_HORIZONTAL_V;
        private float MAX_VERTICAL_V;

        internal Physics(IGameObject gameObject, Vector2 position, IPhysicsConstants constants)
        {
            GRAVITY = constants.GRAVITY;
            FORCE_HORIZONTAL_AGAINST = constants.FORCE_HORIZONTAL_AGAINST;
            GAMEOBJECT_FORCE_UP = constants.GAMEOBJECT_FORCE_UP;
            GAMEOBJECT_FORCE_HORIZONTAL = constants.GAMEOBJECT_FORCE_HORIZONTAL;
            MAX_HORIZONTAL_V = constants.MAX_HORIZONTAL_V;
            MAX_VERTICAL_V = constants.MAX_VERTICAL_V;

            this.gameObject = gameObject;
            this.position = position;

            acceleration = new Vector2(0, 0);
            velocity = new Vector2(0, 0);
        }
        public void FreeFall()
        {
            acceleration.Y = GRAVITY;
        }

        public void Jump()
        {
            acceleration.Y = -GAMEOBJECT_FORCE_UP;
        }

        public void MoveUp()
        {
            // Deprecated.
        }

        public void MoveLeft()
        {
            acceleration.X = -GAMEOBJECT_FORCE_HORIZONTAL;
        }

        public void MoveRight()
        {

            acceleration.X = GAMEOBJECT_FORCE_HORIZONTAL;
        }

        public void MoveDown()
        {
            // Depricated
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
            velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(acceleration.X) * MAX_HORIZONTAL_V);
            velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * MAX_VERTICAL_V);

            position.X += (int)Math.Ceiling(velocity.X);
            position.Y += (int)Math.Ceiling(velocity.Y);

            Loop();
            Stop();
            FreeFall();
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

        private void Loop()
        {
            
            if (position.X <= 0)
                position.X = 400;
            else if (position.X >= 400)
                position.X = 0;

            if (position.Y >= 240)
                position.Y = 0;
            else if (position.Y <= 0)
                position.Y = 240;
                
        } 
        public void Stop()
        {
            if (velocity.X != 0 && Math.Sign(velocity.X) != Math.Sign(velocity.X + acceleration.X))
            {
                velocity.X = 0;
                acceleration.X = 0;
            }

            if (velocity.Y != 0 && Math.Sign(velocity.Y) != Math.Sign(velocity.Y + acceleration.Y))
            {
                velocity.Y = 0;
                acceleration.Y = 0;
            }

            if (acceleration.X != 0)
                velocity.X += (-Math.Sign(velocity.X)) * FORCE_HORIZONTAL_AGAINST;

            if (acceleration.Y != 0)
                velocity.Y += (-Math.Sign(velocity.Y)) * GRAVITY;
        }
    }

    
}
