using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class AnimationPhysics : Physics, IAnimationPhysics
    {

        private Action velocityUpdater;
        private Action positionUpdater;
        private Action gravityUpdater;
        private Action frictionUpdater;
        private Dictionary<Side, Action<int>> animoveaction;
    

        public AnimationPhysics(IGameObject gameObject, Vector2 position, IPhysicsConstants constants) : base(gameObject, position, constants)
        {
            animoveaction = new Dictionary<Side, Action<int>>()
            {
                { Side.Left,new Action<int>((d)=> this.position.X -=d) },
                { Side.Right,new Action<int>((d)=> this.position.X +=d) },
                { Side.Up,new Action<int>((d)=> this.position.Y -=d) },
                { Side.Left,new Action<int>((d)=> this.position.Y +=d) }
            };

            SetDefautUpdators();
        }

        private void SetDefautUpdators()
        {
            velocityUpdater = () =>
            {
                velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(acceleration.X) * max_X_V);
                velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * max_Y_V);
            };

            positionUpdater = () =>
            {
               position.X = (int)(position.X + velocity.X);
               position.Y = (int)(position.Y + velocity.Y);
            };

            frictionUpdater = () => { };

            gravityUpdater = () =>
            {
                acceleration.Y = gravityConstant;
            };
        }
        public void IncrementMove(Side side, int distance)
        {
            animoveaction[side].Invoke(distance);
        }

        public void FuctionMove(Func<Vector2, Vector2> trajectory)
        {
            positionUpdater = () =>
            { position = trajectory(position); };

            gravityUpdater = () => { };
        }

        public override void Move(Side side)
        {
            moveActions[side].Invoke();
            frictionUpdater = () => FrictionStop(side);           
        }

        public override void MoveMaxSpeed(Side side)
        {
            moveMaxSpeedActions[side].Invoke();
            velocityUpdater = () =>
            {
                velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(velocity.X) * max_X_V);
                velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(velocity.Y) * max_Y_V);
            };
        }

        public override void Update()
        {
            gravityUpdater.Invoke();
            velocityUpdater.Invoke();
            positionUpdater.Invoke();
            frictionUpdater.Invoke();
        }

        public override void LeftStop(Rectangle collisionArea)
        {
            position.X += collisionArea.Width;
            Stop(Side.Horizontal);
        }

        public override void RightStop(Rectangle collisionArea)
        {
            position.X -= collisionArea.Width;
            Stop(Side.Horizontal);
        }

        public override void UpStop(Rectangle collisionArea)
        {
            position.Y += collisionArea.Height;
            Stop(Side.Vertical);
        }

        public override void DownStop(Rectangle collisionArea)
        {
            position.Y -= collisionArea.Height;
            Stop(Side.Vertical);
        }



    }
}
