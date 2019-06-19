using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;

namespace Gamespace.Koopas
{
    class Koopa : AbstractGameStatefulObject<IEnemyState>, IEnemy
    {
        public Koopa(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new KoopaMovingLeftState(this);
            SetSprite();

        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void SlideLeft()
        {
            GameObjectPhysics.JumpMaxSpeed(Side.Left);
        }

        public void SlideRight()
        {
            GameObjectPhysics.JumpMaxSpeed(Side.Right);
        }

        public void TakeDamage()
        {
            State.TakeDamage();
        }

        public override void Update()
        {
            Sprite.Update();

            // This can be reworked by adding this CONSTANT ACCEL functionality into Physics.
            if (State.GetType() == typeof(KoopaMovingLeftState))
            {
                GameObjectPhysics.JumpMaxSpeed(Side.Left);
            }
            else if (State.GetType() == typeof(KoopaMovingRightState))
            {
                GameObjectPhysics.JumpMaxSpeed(Side.Right);
            }
            GameObjectPhysics.Update();
            PositionOnScreen = GameObjectPhysics.GetPosition();
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            base.CollideLeft(collisionArea);
            ChangeDirection();
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            base.CollideRight(collisionArea);
            ChangeDirection();
        }


    }
}
