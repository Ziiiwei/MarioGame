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

        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 acceleration;
        protected (PhysicalStatus, Side) objectPhysicalState;
        public Vector2 Position { get => position; }
        public Vector2 Velocity { get => velocity; }
        public (PhysicalStatus, Side) ObjectPhysicalState { get => objectPhysicalState; }
        public IGameObject gameObject { get; set; }

        protected Dictionary<Side, Action> moveMaxSpeedActions;
        protected Dictionary<Side, Action> moveActions;

        protected readonly float G;
        protected readonly float A;

        protected readonly float MAX_X_V;
        protected readonly float MAX_Y_V;

        private readonly float FRICTION;

        public Physics(IGameObject gameObject, Vector2 position, IPhysicsConstants constants)
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

            moveActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => acceleration.Y = -A)},
                {Side.Down, new Action(() => acceleration.Y = A)},
                {Side.Left, new Action(() => acceleration.X = -A)},
                {Side.Right, new Action(() => acceleration.X = A)}
            };

            moveMaxSpeedActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => velocity.Y = -MAX_Y_V)},
                {Side.Down, new Action(() => velocity.Y = MAX_Y_V)},
                {Side.Left, new Action(() => velocity.X = -MAX_X_V)},
                {Side.Right, new Action(() => velocity.X = MAX_X_V)}
            };

            DeterminePhysicalState();
        }
        protected virtual void FreeFall()
        {
            acceleration.Y = G;
        }

        public virtual void Move(Side side)
        {
            moveActions[side].Invoke();
        }

        public virtual void MoveMaxSpeed(Side side)
        {
            moveMaxSpeedActions[side].Invoke();
        }


        public virtual void LeftStop(Rectangle collisionArea)
        {
            position.X = position.X + collisionArea.Width;
            velocity.X = 0;
            acceleration.X = 0;
            DeterminePhysicalState();

        }

        public virtual void RightStop(Rectangle collisionArea)
        {
            position.X = position.X - collisionArea.Width;
            velocity.X = 0;
            acceleration.X = 0;
            DeterminePhysicalState();

        }

        public virtual void UpStop(Rectangle collisionArea)
        {
            position.Y = position.Y + collisionArea.Height;
            velocity.Y = 0;
            acceleration.Y = 0;
            DeterminePhysicalState();
        }

        public virtual void DownStop(Rectangle collisionArea)
        {
            position.Y = position.Y - collisionArea.Height;
            velocity.Y = 0;
            acceleration.Y = 0;
            DeterminePhysicalState();
        }

        public virtual void Update()
        {
            FreeFall();

            velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(acceleration.X) * MAX_X_V);
            velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * MAX_Y_V);

            position.X += velocity.X;
            position.Y += velocity.Y;

            DeterminePhysicalState();
        }

        public virtual Vector2 GetPosition()
        {
            return position;
        }

        public virtual Vector2 GetVelocity()
        {
            return velocity;
        }

        /* Will return the signed integer which has the least magnitude */
        protected float MinimumMagnitude(float a, float b)
        {
            return Math.Abs(a) < Math.Abs(b) ? a : b;
        }

        //to check if the obj is in free fall or not
        //if is free fall, then dir can be any
        //if not dir can only be left and right
        protected void DeterminePhysicalState()
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
        public virtual void FrictionStop(Side side)
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

        public virtual void Stop(Side side)
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
