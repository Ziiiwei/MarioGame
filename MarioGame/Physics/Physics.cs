using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.Controllers;

namespace Gamespace
{
    public class Physics : IPhysics
    {

        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration;
        private (PhysicalStatus, Side) objectPhysicalState;
        public Vector2 Position { get => position; }
        public Vector2 Velocity { get => velocity; }
        public (PhysicalStatus, Side) ObjectPhysicalState { get => objectPhysicalState; }
        public IGameObject gameObject { get; set; }

    

        private readonly float G;
        private readonly float A;

        private readonly float MAX_X_V;
        private readonly float MAX_Y_V;

        private readonly float FRICTION;

        internal Physics(IGameObject gameObject, Vector2 position, IPhysicsConstants constants)
        {
            G = constants.G;
            A = constants.A;  
            MAX_X_V = constants.MAX_X_V;
            MAX_Y_V = constants.MAX_Y_V;
            FRICTION = constants.FRICTION;

            this.gameObject = gameObject;
            this.position = position;

            acceleration = new Vector2(0, 0);
            velocity = new Vector2(0, 0);
            DeterminePhysicalState();
        }
        private void FreeFall()
        {
            acceleration.Y = G;
        }

        public void MoveMaxSpeed(Side side)
        {
            switch (side)
            {
                case Side.Up:
                    acceleration.Y = -A;
                    break;
                case Side.Down:
                    acceleration.Y = A;
                    break;
                case Side.Left:
                    acceleration.X = -A;
                    break;
                case Side.Right:
                    acceleration.X = A;
                    break;
                default:
                    FrictionStop(Side.None);
                    break;

            }
        }

        public void JumpMaxSpeed(Side side)
        {
            switch (side)
            {
                case Side.Up:
                    velocity.Y = -MAX_Y_V;
                    break;
                case Side.Down:
                    velocity.Y = MAX_Y_V;
                    break;
                case Side.Left:
                    velocity.X = -MAX_X_V;
                    break;
                case Side.Right:
                    velocity.X = MAX_X_V;
                    break;
                default:
                    Stop(Side.None);
                    break;

            }
        }


        public void LeftStop(Rectangle collisionArea)
        {
            position.X = position.X + collisionArea.Width;
            velocity.X = 0;
            acceleration.X = 0;
            DeterminePhysicalState();

        }

        public void RightStop(Rectangle collisionArea)
        {
            position.X = position.X - collisionArea.Width;
            velocity.X = 0;
            acceleration.X = 0;
            DeterminePhysicalState();

        }

        public void UpStop(Rectangle collisionArea)
        {
            position.Y = position.Y + collisionArea.Height;
            velocity.Y = 0;
            acceleration.Y = 0;
            DeterminePhysicalState();
        }

        public void DownStop(Rectangle collisionArea)
        {
            position.Y = position.Y - collisionArea.Height;
            velocity.Y = 0;
            acceleration.Y = 0;
            DeterminePhysicalState();
        }

        public void Update()
        {
            FreeFall();

            velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(acceleration.X) * MAX_X_V);
            velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * MAX_Y_V);

            position.X += velocity.X;
            position.Y += velocity.Y;

            DeterminePhysicalState();
            //Loop();
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        /* Will return the signed integer which has the least magnitude */
        private float MinimumMagnitude(float a, float b)
        {
            return Math.Abs(a) < Math.Abs(b) ? a : b;
        }

        private void Loop()
        {
            /*
            if (position.X <= 0)
                position.X = MarioGame.WINDOW_WIDTH/MarioGame.SCALE;
            else if (position.X >= MarioGame.WINDOW_WIDTH / MarioGame.SCALE)
                position.X = 0;
                */

            if (position.Y >= MarioGame.WINDOW_HEIGHT / MarioGame.SCALE)
                position.Y = 0;
            else if (position.Y <= 0)
                position.Y = MarioGame.WINDOW_HEIGHT / MarioGame.SCALE;
                
        } 

        //to check if the obj is in free fall or not
        //if is free fall, then dir can be any
        //if not dir can only be left and right
        private void DeterminePhysicalState()
        {
            Side dir;
            PhysicalStatus status;
            if (acceleration.Y == G)
            {
                status = PhysicalStatus.Fall;
                if (velocity.Y == 0)
                {
                    dir = Side.None;
                }
                else if (velocity.Y > 0)
                {
                    dir = Side.Up;
                }
                else
                {
                    dir = Side.Down;
                }

            } else
            {
                status = PhysicalStatus.Ground;
                if (velocity.X == 0)
                {
                    dir = Side.None;
                } else if(velocity.X>0)
                {
                    dir = Side.Right;
                } else
                {
                    dir = Side.Left;
                }

                objectPhysicalState = (status, dir);
            }

            
        }
        public void FrictionStop(Side side)
        {
            if (side == Side.Right || side == Side.Left || side == Side.None)
            {
                if (velocity.X != 0 && Math.Sign(velocity.X) != Math.Sign(velocity.X + acceleration.X))
                {
                    velocity.X = 0;
                    acceleration.X = 0;
                }
                if (velocity.X != 0)
                    acceleration.X = (-Math.Sign(velocity.X)) * FRICTION;
            }

            if (side == Side.Up || side == Side.Down || side == Side.None)
            {

                if (velocity.Y != 0 && Math.Sign(velocity.Y) != Math.Sign(velocity.Y + acceleration.Y))
                {
                        velocity.Y = 0;
                        acceleration.Y = 0;
                }
                if (velocity.Y != 0)
                        acceleration.Y = (-Math.Sign(velocity.Y)) * FRICTION;
                
            }
        }

        public void Stop(Side side)
        {
            if (side == Side.Right || side == Side.Left || side == Side.None)
            {
                velocity.X = 0;
                acceleration.X = 0;
            }

            if (side == Side.Up || side == Side.Down || side == Side.None)
            {
                velocity.Y = 0;
                acceleration.Y = 0;
            }
        }
    }

    
}
