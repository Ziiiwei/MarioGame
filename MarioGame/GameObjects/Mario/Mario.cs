using Gamespace.Projectiles;
using Gamespace.Sounds;
using Gamespace.Sprites;
using Gamespace.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Gamespace.Multiplayer;

namespace Gamespace
{
    internal class Mario : AbstractGameStatefulObject<IMarioState>, IMario
    {
        public IMarioPowerUpState PowerUpState { get; set; }
        public IMarioPowerUpState PreviousState { get; set; }
        public IFireable Projectiles { get; set; }
        private IPlayer player;

        public Mario(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new RightStandingMarioState(this);
            PowerUpState = new MarioSmallState();
            SetSprite();
            Projectiles = new ProjectileLauncher(this);
        }

        protected override void SurrogateUpdate()
        {
            base.SurrogateUpdate();
            GameObjectPhysics.Update();
            GameObjectPhysics.FrictionStop(Side.Right);
            State.FrictionStop();

            positionOnScreen = GameObjectPhysics.GetPosition();
        }

        public void Crouch()
        {
            State.Crouch();    
        }

        public void Jump()
        {
            State.Jump();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
        }

        public void MoveRight()
        {
            State.MoveRight();
        }

        public void PowerDown()
        {
            PowerUpState.PowerDown(this);
            UpdateArt();
        }

        public void PowerUp()
        {
            SoundManager.Instance.PlaySoundEffect("PowerUp");
            PowerUpState.PowerUp(this);
        }

        public void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, PowerUpState.GetType().Name);
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, PowerUpState.GetType().Name);
        }

        public void Bounce()
        {
            GameObjectPhysics.MoveMaxSpeed(Side.Up);
        }

        public void Die()
        {
            GameObjectPhysics.MoveMaxSpeed(Side.Up);
            World.Instance.MaskCollision(this);
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySoundEffect("MarioDies");
        }

        public override void CollideDown(Rectangle collisionArea)
        {
            base.CollideDown(collisionArea);
            State.Land();
        }

        public void Fire()
        {
             PowerUpState.Fire(this);
        }

        public void Coin()
        {
        }

        public void SetPlayer(IPlayer player)
        {
            this.player = player;
        }
    }
}
