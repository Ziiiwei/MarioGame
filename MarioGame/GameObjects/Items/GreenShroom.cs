using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;
using Gamespace.Sprites;
using Gamespace.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gamespace.Data;

namespace Gamespace.Items
{
    class GreenShroom : AbstractGameStatefulObject<IShroomState>, IMovableItem, IItem
    {
        private static int[] bumpOffsets = Numbers.BUMP_OFFSETS;
        private int bumpCounter = 0;

        public GreenShroom(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new GreenShroomUpState(this);
            SetSprite();
            SoundManager.Instance.PlaySoundEffect("PowerUpAppears");
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Consume()
        {
            World.Instance.RemoveFromWorld(this);
        }

        protected override void SurrogateUpdate()
        {
            base.SurrogateUpdate();
            if (State.GetType() == typeof(GreenShroomUpState))
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
                positionOnScreen = GameObjectPhysics.Position;
            }

        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            if (State.GetType() != typeof(GreenShroomUpState))
            {
                base.CollideLeft(collisionArea);
                ChangeDirection();
            }
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            if (State.GetType() != typeof(GreenShroomUpState))
            {
                base.CollideRight(collisionArea);
                ChangeDirection();
            }
        }

        public override void CollideDown(Rectangle collisionArea)
        {
            if (State.GetType() != typeof(GreenShroomUpState))
            {
                base.CollideDown(collisionArea);
            }
        }

        public override void CollideUp(Rectangle collisionArea)
        {
            if (State.GetType() != typeof(GreenShroomUpState))
            {
                base.CollideUp(collisionArea);
            }
        }

    }
}