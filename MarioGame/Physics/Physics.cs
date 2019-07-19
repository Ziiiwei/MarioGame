using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.Controllers;
using Gamespace.Data;

namespace Gamespace
{
    public class Physics : IPhysics
    {

        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 acceleration;
        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public Vector2 Acceleration { get => acceleration; set => acceleration = value; }
        public (float G, float A, float X_V, float Y_V, float F) PhysicsConstants { get; set; }
        public IGameObject gameObject { get; set; }

        protected Dictionary<Side, Action> moveMaxSpeedActions;
        protected Dictionary<Side, Action> moveActions;
        protected Dictionary<Side, Action> climbActions;

        protected readonly float gravityConstant;
        protected readonly float accelConstant;

        protected readonly float max_X_V;
        protected readonly float max_Y_V;

        protected readonly float FRICTION;

        private Action freefall;
        private Action frictionstop;

        public Physics(IGameObject gameObject, Vector2 position, (float G, float A, float X_V, float Y_V, float F) constants)
        {
           

            this.gameObject = gameObject;
            this.position = position;
            PhysicsConstants = constants;
            accelConstant = constants.A;
            gravityConstant = constants.G;
            max_X_V = constants.X_V;
            max_Y_V = constants.Y_V;
            FRICTION = constants.F;

            acceleration = new Vector2(0, 0);
            velocity = new Vector2(0, 0);

            moveActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => acceleration.Y = -accelConstant)},
                {Side.Down, new Action(() => acceleration.Y = accelConstant)},
                {Side.Left, new Action(() => acceleration.X = -accelConstant)},
                {Side.Right, new Action(() => acceleration.X = accelConstant)}
            };

            moveMaxSpeedActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => velocity.Y = -max_Y_V)},
                {Side.Down, new Action(() => velocity.Y = max_Y_V)},
                {Side.Left, new Action(() => velocity.X = -max_X_V)},
                {Side.Right, new Action(() => velocity.X = max_X_V)}
            };

            climbActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => {acceleration.Y = -accelConstant/100; velocity.Y = -max_Y_V/5; })},
                {Side.Down, new Action(() => {acceleration.Y = accelConstant/100; velocity.Y = max_Y_V/5; })},
                {Side.Left, new Action(() => {acceleration.X = -accelConstant/100; velocity.X = -max_Y_V/5; })},
                {Side.Right, new Action(() => {acceleration.X = accelConstant/100; velocity.X = max_Y_V/5; })},
            };

            freefall = () => FreeFall();
            frictionstop = () => { };
        }

        public void Jump()
        {
        }
        protected virtual void FreeFall()
        {
            acceleration.Y = gravityConstant;
            frictionstop = () => { };
        }

        public virtual void Move(Side side)
        {
            moveActions[side].Invoke();
            freefall = () => FreeFall();
            frictionstop = () => { };
        }

        public virtual void MoveMaxSpeed(Side side)
        {
            moveMaxSpeedActions[side].Invoke();
            freefall = () => FreeFall();
            frictionstop = () => { };
        }

        public virtual void Climb(Side side)
        {
        
            climbActions[side].Invoke();

            freefall = () => { };
            frictionstop = () => FrictionStop(Side.Vertical);
        }


        public virtual void LeftStop(Rectangle collisionArea)
        {
            position.X += collisionArea.Width;
            Stop(Side.Horizontal);

        }

        public virtual void RightStop(Rectangle collisionArea)
        {
            position.X -= collisionArea.Width;
            Stop(Side.Horizontal);

        }

        public virtual void UpStop(Rectangle collisionArea)
        {
            position.Y += collisionArea.Height;
            Stop(Side.Vertical);
            frictionstop = () => { };
        }

        public virtual void DownStop(Rectangle collisionArea)
        {
            position.Y -= collisionArea.Height;
            Stop(Side.Vertical);
            freefall = () => { };
            frictionstop = () => { };
        }

        public virtual void Update()
        {
            freefall.Invoke();

            velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(acceleration.X) * max_X_V);
            velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * max_Y_V);

            position.X += velocity.X;
            position.Y += velocity.Y;

            frictionstop.Invoke();
        }

        protected float MinimumMagnitude(float a, float b)
        {
            return Math.Abs(a) < Math.Abs(b) ? a : b;
        }

        public virtual void FrictionStop(Side side)
        {
            if (side == Side.Right || side == Side.Left || side == Side.None || side == Side.Horizontal)
            {
                if (velocity.X != 0 && Math.Sign(velocity.X) != Math.Sign(velocity.X + acceleration.X))
                {
                    velocity.X = 0;
                    acceleration.X = 0;
                }
                if (velocity.X != 0)
                    acceleration.X = (-Math.Sign(velocity.X)) * FRICTION;
            }

            if (side == Side.Up || side == Side.Down || side == Side.None || side == Side.Vertical)
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
            if (side == Side.Right || side == Side.Left || side == Side.None || side == Side.Horizontal)
            {
                velocity.X = 0;
                acceleration.X = 0;
            }

            if (side == Side.Up || side == Side.Down || side == Side.None || side == Side.Vertical)
            {
                velocity.Y = 0;
                acceleration.Y = 0;
            }
        }

        public void ResoveCollision(Side side, Rectangle collisionArea)
        {
            throw new NotImplementedException();
        }

        public void IncrementMove(Side side, int distance)
        {
            throw new NotImplementedException();
        }

        public void TrajectMove(Func<Vector2, int, Vector2> trajectory)
        {
            throw new NotImplementedException();
        }
    }
}
