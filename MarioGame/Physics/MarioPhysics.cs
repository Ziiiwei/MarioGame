using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class MarioPhysics : BasePhysics
    {
        private Dictionary<Side, Action> climbActions;
        private Dictionary<Side, Action> moveActions;
        private bool previousJumpCall;
        private bool maxYSpeedReach;
        private Action jumpUpdator;
        public MarioPhysics(IGameObject gameObject, Vector2 position,(float G, float A, float X_V, float Y_V, float F) constants) 
            :base(gameObject,position,constants)
        {
            climbActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => {acceleration.Y = -PhysicsConstants.A/100; velocity.Y = -PhysicsConstants.Y_V/5; })},
                {Side.Down, new Action(() => {acceleration.Y = PhysicsConstants.A/100; velocity.Y = PhysicsConstants.Y_V/5; })},
                {Side.Left, new Action(() => {acceleration.X = -PhysicsConstants.A/100; velocity.X = -PhysicsConstants.Y_V/5; })},
                {Side.Right, new Action(() => {acceleration.X = PhysicsConstants.A/100; velocity.X = PhysicsConstants.Y_V/5; })},
            };

            moveActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => acceleration.Y = -PhysicsConstants.A)},
                {Side.Down, new Action(() => acceleration.Y = PhysicsConstants.A)},
                {Side.Left, new Action(() => acceleration.X = -PhysicsConstants.A)},
                {Side.Right, new Action(() => acceleration.X = PhysicsConstants.A)}
            };

            jumpUpdator = () => previousJumpCall = false;
            previousJumpCall = false;
            maxYSpeedReach = false;

        }
        public override void Move(Side side)
        {
            moveActions[side].Invoke();
        }
        public override void Climb(Side side)
        {
            climbActions[side].Invoke();
            gravityUpdater = () => { };
            frictionUpdater = () => FrictionStop(Side.Vertical);
        }

        public override void Jump()
        {
            SetDefautUpdators();
            jumpUpdator = () => { };

            if (Math.Abs(velocity.Y) < PhysicsConstants.Y_V  && previousJumpCall && !maxYSpeedReach)
            {
                position.Y -= 15f;
                velocity.Y = MinimumMagnitude(velocity.Y-PhysicsConstants.G*5,-PhysicsConstants.Y_V);
            } 

            if (Math.Abs(velocity.Y) >= PhysicsConstants.Y_V)
            {
                maxYSpeedReach = true;
            }

            previousJumpCall = true;
        }

        public override void DownStop(Rectangle collisionArea)
        {
            base.DownStop(collisionArea);
            frictionUpdater = ()=>FrictionStop(Side.Horizontal);

            if (!previousJumpCall)
            {
                maxYSpeedReach = false;
            }
        }

        public override void UpStop(Rectangle collisionArea)
        {
            base.UpStop(collisionArea);
            maxYSpeedReach = true;
        }
        public override void Update()
        {
            base.Update();

            jumpUpdator.Invoke();
            jumpUpdator = () =>
            {
                previousJumpCall = false;
            };
        }

        public override bool MaxSpeedReached(Side side)
        {
            if (side is Side.Up || side is Side.Horizontal)
            {
                return maxYSpeedReach;
            }
            else
            {
                return base.MaxSpeedReached(side);
            }
        }
    }
}
