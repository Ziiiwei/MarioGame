using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sounds;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gamespace.Data;


namespace Gamespace.Items
{
    class Coin : AbstractGameObject, IItem
    {
        private static int[] bumpOffsets = Numbers.BUMP_OFFSETS;
        private int bumpCounter = 0;

        public Coin(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            SetSprite();
        }

        public void Consume()
        {
            SoundManager.Instance.PlaySoundEffect(this.GetType().Name);
            World.Instance.RemoveFromWorld(this);
        }

        protected override void SurrogateUpdate()
        {
            base.SurrogateUpdate();

            if (bumpCounter < bumpOffsets.Count())
            {
                positionOnScreen.Y -= bumpOffsets[bumpCounter];
                bumpCounter += 1;
            }
            else
            {
                Consume();
            }
        }
    }
}
