using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace
{
   public class BasePhysics : IPhysics
    {
        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 acceleration;

        public IGameObject gameObject { get; set; }

        protected Action velocityUpdater;
        protected Action positionUpdater;
        protected Action gravityUpdater;
        protected Action frictionUpdater;
        protected int updateTimer;
        protected Vector2 initialPostion;

        private Dictionary<Side, Action<int>> animoveaction;
        private Dictionary<Side, Action> moveMaxSpeedActions;
        private Dictionary<Side, Action> moveActions;
        private Dictionary<Side, Action<Rectangle>> collisionActions;

        public Vector2 Position { get=> position; set =>position=value; }
        public Vector2 Velocity { get=> velocity ; set =>velocity= value ; }
        public Vector2 Acceleration { get =>acceleration ; set =>acceleration = value; }
        public (float G, float A, float X_V, float Y_V, float F) PhysicsConstants { get ; set ; }

        public BasePhysics(IGameObject gameObject, Vector2 position, (float G, float A, float X_V, float Y_V, float F) constants) {

            this.gameObject = gameObject;
            this.position = position;
            initialPostion = position;
            PhysicsConstants = constants;

            animoveaction = new Dictionary<Side, Action<int>>()
            {
                { Side.Left,new Action<int>((d)=> this.position.X -=d) },
                { Side.Right,new Action<int>((d)=> this.position.X +=d) },
                { Side.Up,new Action<int>((d)=> this.position.Y -=d) },
                { Side.Left,new Action<int>((d)=> this.position.Y +=d) }
            };
            moveActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => acceleration.Y = -PhysicsConstants.A)},
                {Side.Down, new Action(() => acceleration.Y = PhysicsConstants.A)},
                {Side.Left, new Action(() => acceleration.X = -PhysicsConstants.A)},
                {Side.Right, new Action(() => acceleration.X = PhysicsConstants.A)}
            };

            moveMaxSpeedActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => velocity.Y = -PhysicsConstants.Y_V)},
                {Side.Down, new Action(() => velocity.Y = PhysicsConstants.Y_V)},
                {Side.Left, new Action(() => velocity.X = -PhysicsConstants.X_V)},
                {Side.Right, new Action(() => velocity.X = PhysicsConstants.X_V)}
            };

            collisionActions = new Dictionary<Side, Action<Rectangle>>()
            {
                { Side.Up, new Action<Rectangle>((r)=>UpStop(r))},
                { Side.Down, new Action<Rectangle>((r)=>DownStop(r))},
                 { Side.Left, new Action<Rectangle>((r)=>LeftStop(r))},
                 { Side.Right, new Action<Rectangle>((r)=>RightStop(r))}
            };

            SetDefautUpdators();
        }

        private void SetNullUpdators()
        {
            velocityUpdater = () => { };
            positionUpdater = () => { };
            frictionUpdater = () => { };
            gravityUpdater = () => { };
        }
        private void SetDefautUpdators()
        {
            velocityUpdater = () =>
            {
                velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(acceleration.X) * PhysicsConstants.X_V);
                velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * PhysicsConstants.Y_V);
            };

            positionUpdater = () =>
            {
                position.X = (int)(position.X + velocity.X);
                position.Y = (int)(position.Y + velocity.Y);
            };

            frictionUpdater = () => { };

            gravityUpdater = () =>
            {
                acceleration.Y = PhysicsConstants.G;
            };
        }
        public virtual void IncrementMove(Side side, int distance)
        {
            animoveaction[side].Invoke(distance);
        }


        public virtual void Move(Side side)
        {
            moveActions[side].Invoke();
            frictionUpdater = () => FrictionStop(side);
        }

        public virtual void MoveMaxSpeed(Side side)
        {
            moveMaxSpeedActions[side].Invoke();
            velocityUpdater = () =>
            {
                velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(velocity.X) * PhysicsConstants.X_V);
                velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(velocity.Y) * PhysicsConstants.Y_V);
            };
        }

        public virtual void Update()
        {
            gravityUpdater.Invoke();
            velocityUpdater.Invoke();
            positionUpdater.Invoke();
            frictionUpdater.Invoke();

            updateTimer++;
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
        }

        public virtual void DownStop(Rectangle collisionArea)
        {
            position.Y -= collisionArea.Height;
            Stop(Side.Vertical);
        }

        public virtual void Jump()
        {
        }

        public virtual void Climb(Side side)
        {
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

        public virtual void FrictionStop(Side side)
        {
            if (side == Side.Right || side == Side.Left || side == Side.None || side == Side.Horizontal)
            {
                if (velocity.X != 0 && Math.Sign(velocity.X) != Math.Sign(velocity.X + acceleration.X))
                {
                    Stop(Side.Horizontal);
                }
                if (velocity.X != 0)
                    acceleration.X = (-Math.Sign(velocity.X)) * PhysicsConstants.F;
            }

            if (side == Side.Up || side == Side.Down || side == Side.None || side == Side.Vertical)
            {

                if (velocity.Y != 0 && Math.Sign(velocity.Y) != Math.Sign(velocity.Y + acceleration.Y))
                {
                    Stop(Side.Vertical);
                }
                if (velocity.Y != 0)
                    acceleration.Y = (-Math.Sign(velocity.Y)) * PhysicsConstants.F;

            }
        }

        public virtual void ResoveCollision(Side side, Rectangle collisionArea)
        {
            collisionActions[side].Invoke(collisionArea);
        }

        public virtual void TrajectMove(Func<Vector2, int, Vector2> trajectory)
        {
            SetNullUpdators();
            updateTimer = 0;
            initialPostion = position;
            positionUpdater = () => position = trajectory(initialPostion, updateTimer);
            
        }

        protected float MinimumMagnitude(float a, float b)
        {
            return Math.Abs(a) < Math.Abs(b) ? a : b;
        }
    }
}
