
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
                bumpReward = null;
            }
            State.Bump();
            
        }

        public void Destroy()
        {
            World.Instance.RemoveFromWorld(this);
        }

        protected override void SurrogateUpdate()
        {
            base.SurrogateUpdate();
            GameObjectPhysics.Update();
            positionOnScreen = GameObjectPhysics.GetPosition();
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }
    }
}
