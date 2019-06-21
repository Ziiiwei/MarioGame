
using Gamespace;
using Gamespace.Blocks;
using Gamespace.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    internal class BrickBlock : AbstractGameStatefulObject<IBlockBumpState>, IBumpable, IDestroyable
    {
        private static int[] bumpOffsets = { 0, 1, 2, 3, -1, -2, -3 };
        private int bumpCounter = -1;
        private Type bumpReward;

        public BrickBlock(Vector2 positionOnScreen, Type bumpReward) : base(positionOnScreen)
        {
            State = new BlockIsNotBumpedState(this);
            SetSprite();
            this.bumpReward = bumpReward;
        }
        public BrickBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new BlockIsNotBumpedState(this);
            SetSprite();
        }

        public void Bump()
        {
            if (bumpReward != null)
            {
                World.Instance.AddGameObject((IGameObject)Activator.CreateInstance(bumpReward, positionOnScreen));
            }
            else if (State.GetType() == typeof(BlockIsNotBumpedState))
            {
                State = new BlockIsBumpedState(this);
                bumpCounter = 0;
            }
        }

        public void Destroy()
        {
            World.Instance.RemoveFromWorld(this.Uid);
        }

        public override void Update()
        {
            base.Update();
            if (State.GetType() == typeof(BlockIsBumpedState))
            {
                positionOnScreen.Y -= bumpOffsets[bumpCounter];
                bumpCounter = (bumpCounter + 1) % bumpOffsets.Length;
            }
            
            if (bumpCounter == 0)
            {
                State = new BlockIsNotBumpedState(this);
            }

        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }
    }
}
