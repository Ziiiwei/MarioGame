using Gamespace.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class Fireball : AbstractGameStatefulObject<IProjectileState>, IProjectile
    {
        private static readonly Dictionary<Side, Type> initialOrientation;

        static Fireball()
        {
            initialOrientation = new Dictionary<Side, Type>()
            {
                {Side.Left, typeof(LeftMovingProjectile) },
                {Side.Right, typeof(RightMovingProjectile) }
            };
        }

        public Fireball(Vector2 positionOnScreen, Side side) : base(positionOnScreen)
        {
            State = (IProjectileState) Activator.CreateInstance(initialOrientation[side], this);
            SetSprite();
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void MoveLeft()
        {
            GameObjectPhysics.MoveMaxSpeed(Side.Left);
        }

        public void MoveRight()
        {
            GameObjectPhysics.MoveMaxSpeed(Side.Right);
        }

        protected override void SetSprite()
        {
            Sprite =  SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }

        public override void Update()
        {
            base.Update();
            GameObjectPhysics.Update();
            positionOnScreen = GameObjectPhysics.GetPosition();
        }
    }
}
