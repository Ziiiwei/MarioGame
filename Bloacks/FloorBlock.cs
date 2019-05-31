using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FloorBlock : IBlocks
    {
        public ISprite Sprite { get; set; }
        private Vector2 positionOnScreen;

        public FloorBlock(Vector2 positionOnScreen)
        {
            Sprite = SpriteFactory.Instance.GetSprite("FloorBlock");
            this.positionOnScreen = positionOnScreen;
        }

        public void MarioHitBlock()
        {
            //nothingh
        }

        public void Update()
        {
            //nothing
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            var spriteTextureAndRectangle = Sprite.GetSprite();

            spriteBatch.Draw(texture: spriteTextureAndRectangle.Item1, position: positionOnScreen,
                sourceRectangle: spriteTextureAndRectangle.Item2);
        }
    }
}