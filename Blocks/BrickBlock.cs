using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Blocks
{
    class BrickBlock : AbstractGameObject
    {
        public BrickBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            Sprite = SpriteFactory.Instance.GetSprite(this);
        }

        public void MarioHitBlock()
        {
            //nothingh
        }
    }
}
