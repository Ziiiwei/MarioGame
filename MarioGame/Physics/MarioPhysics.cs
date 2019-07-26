using Gamespace.Data;
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
        private bool maxYSpeedReach;
        private bool keepJumpAble;
        private Action keepJumping;
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

           
            maxYSpeedReach = false;
            keepJumpAble = false;
            keepJumping = () =>  keepJumpAble = false; 

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

            position.Y -= PhysicsConstants.G;
            velocity.Y = -PhysicsConstants.Y_V / 4;

            keepJumpAble = true;
            keepJumping = () => { };

        }

        public void KeepJump()
        {
           
            if (keepJumpAble)
            {
                velocity.Y = MinimumMagnitude(velocity.Y - PhysicsConstants.G * 3, -PhysicsConstants.Y_V);
            }
            if (Math.Abs(velocity.Y) >= PhysicsConstants.Y_V)
            {
                maxYSpeedReach = true;
            }
            keepJumping = () => { };
        }

        public override void DownStop(Rectangle collisionArea)
        {
            base.DownStop(collisionArea);
            frictionUpdater = ()=>FrictionStop(Side.Horizontal);          
        }

        public override void UpStop(Rectangle collisionArea)
        {
            base.UpStop(collisionArea);
            maxYSpeedReach = true;
        }
        public override void Update()
        {
            base.Update();
            keepJumping.Invoke();
            keepJumping = () => keepJumpAble = false;
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

        public void ReSetMaxSpeedCheck()
        {
            maxYSpeedReach = false;
        }

        public void Die()
        {
            
            Func<Vector2, int, Vector2> dieMove = new Func<Vector2, int, Vector2>((p, t) =>
              {
                  const int DieMoveDistance = Numbers.BLOCK_SPACING_SCALE*2;
                  if (PhysicsConstants.X_V/4*t<= DieMoveDistance)
                  {
                      return new Vector2(p.X, p.Y + PhysicsConstants.X_V / 4 * t);
                  } else
                  {
                      return new Vector2(p.X, p.Y + DieMoveDistance);
                  }
              });
            TrajectMove(dieMove);
        }
    }
}
