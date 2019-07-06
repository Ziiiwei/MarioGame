using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Items
{
    class RedShroom : AbstractGameStatefulObject<IShroomState>, IMovableItem, IItem
    {
        private static int[] bumpOffsets = { 4, 4, 4, 4, 4, 4, 4, 4 };
        private int bumpCounter = 0;

        public RedShroom(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new ShroomMovingUpState(this);
            SetSprite();
            SoundFactory.Instance.PlaySoundEffect("PowerUpAppears");
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Consume()
        {
            World.Instance.RemoveFromWorld(Uid);
        }

        public override void Update()
        {
            base.Update();
            if (State.GetType() == typeof(ShroomMovingUpState))
            {
                positionOnScreen.Y -= bumpOffsets[bumpCounter];
                bumpCounter += 1;

                if (bumpCounter == bumpOffsets.Length)
                {
                    State.ChangeDirection();
                }
            }
            else
            {
                GameObjectPhysics.Update();
                positionOnScreen = GameObjectPhysics.GetPosition();
            }

        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            if (State.GetType() != typeof(ShroomMovingUpState))
            {
                base.CollideLeft(collisionArea);
                ChangeDirection();
            }
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            if (State.GetType() != typeof(ShroomMovingUpState))
            {
                base.CollideRight(collisionArea);
                ChangeDirection();
            }
        }

        public override void CollideDown(Rectangle collisionArea)
        {
            if (State.GetType() != typeof(ShroomMovingUpState))
            {
                base.CollideDown(collisionArea);
            }
        }

        public override void CollideUp(Rectangle collisionArea)
        {
            if (State.GetType() != typeof(ShroomMovingUpState))
            {
                base.CollideUp(collisionArea);
            }
        }

    }
}