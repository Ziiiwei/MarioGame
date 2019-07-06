using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class HiddenBlock : AbstractGameStatefulObject<IBlockBumpState>, IBumpable, IDestroyable
    {
        private Type bumpReward;

        public HiddenBlock(Vector2 positionOnScreen, Type bumpReward) : base(positionOnScreen)
        {
            State = new BlockIsNotBumpedState(this);
            SetSprite();
            this.bumpReward = bumpReward;
        }
        public HiddenBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new BlockIsNotBumpedState(this);
            SetSprite();
        }

        public void Destroy()
        {
            Vector2 newBlockPosition = positionOnScreen;
            World.Instance.RemoveFromWorld(this);
            World.Instance.AddGameObject(new UsedBlock(newBlockPosition));
        }

        public void Bump()
        {
            if (bumpReward != null)
            {
                World.Instance.AddGameObject((IGameObject)Activator.CreateInstance(bumpReward, positionOnScreen));
                bumpReward = null;
            }
            Destroy();
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }

    }
}
