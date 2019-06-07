using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Blocks
{
    public class Block : AbstractGameStatefulObject<IBlock>
    {
        private IBlock State;

        public Block(IBlock state, Vector2 positionOnScreen) : base(positionOnScreen)
        {
            this.State = state;
            this.State.block = this;
            this.Sprite = SpriteFactory.Instance.GetSprite(State);

        }
        public void MarioHitBlock()
        {
            State.MarioHitBlock();
            State.block = this;
        }
        public override void SetState(IBlock newState)
        {
            State = newState;
            this.Sprite = SpriteFactory.Instance.GetSprite(newState);
      
        }

      
    }
}
