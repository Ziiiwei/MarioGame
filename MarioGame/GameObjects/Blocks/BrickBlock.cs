using Gamespace.Sounds;
using Gamespace;
using Gamespace.Blocks;
using Gamespace.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Projectiles;

namespace Gamespace.Blocks
{
    internal class BrickBlock : AbstractGameStatefulObject<IBlockBumpState>, IBumpable, IDestroyable
    {
        public Type bumpReward { get; private set; }

        private MassProjectileLauncher blockExplode;

        public BrickBlock(Vector2 positionOnScreen, Type bumpReward) : base(positionOnScreen)
        {
            State = new BlockIsNotBumpedState(this);
            SetSprite();
            this.bumpReward = bumpReward;
            blockExplode = CharacterWeapeonManager.Instance.GetMassWeapeon(this);
        }
        public BrickBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new BlockIsNotBumpedState(this);
            SetSprite(); blockExplode = CharacterWeapeonManager.Instance.GetMassWeapeon(this);
            blockExplode = CharacterWeapeonManager.Instance.GetMassWeapeon(this);
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
            SoundManager.Instance.PlaySoundEffect("BreakBlock");
            blockExplode.Fire(ShootAngle.None);
            World.Instance.RemoveFromWorld(this);
        }

        protected override void SurrogateUpdate()
        {
            base.SurrogateUpdate();
            GameObjectPhysics.Update();
            positionOnScreen = GameObjectPhysics.Position;
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }
    }
}
