using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class CoinBlock : IBlocks
    {
        public ISprite Sprite { get; set; }
        private Vector2 positionOnScreen;
        private IBlockState State;

        public CoinBlock(Vector2 positionOnScreen)
        {
            this.State = new CoinBlockStateMany(this);
            Sprite = SpriteFactory.Instance.GetSprite(this);
            this.positionOnScreen = positionOnScreen;
        }

        public void MarioHitBlock()
        {
            State.MarioHitBlock();
        }

        public void Update()
        {
            State.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: Sprite.GetTexture(), position: positionOnScreen,
                sourceRectangle: Sprite.GetRectangle(),color: Color.White);
        }

        public void SetState(IBlockState newState)
        {
            State = newState;
        }
    }
}


