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

        public Scoreboard scoreboard { get; set; }

        private Action keepStanding;

        public Mario(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new RightStandingMarioState(this);
            PowerUpState = new MarioSmallState();
            SetSprite();
            Projectiles = new ProjectileLauncher(this);
            keepStanding= () => State.Stand();
        }

        public Mario(Vector2 positionOnScreen, Scoreboard scoreboard) : this(positionOnScreen)
        {
            this.scoreboard = scoreboard;
        }

        protected override void SurrogateUpdate()
        {
            base.SurrogateUpdate();
            GameObjectPhysics.Update();
            State.FrictionStop();
            positionOnScreen = GameObjectPhysics.Position;

            keepStanding.Invoke();
            keepStanding = () => State.Stand();
        }

        public void Crouch()
        {
            int previous_h = Sprite.Height;
            State.Crouch();
            GameObjectPhysics.DownStop(new Rectangle(0, 0, 0, Sprite.Height - previous_h));
            keepStanding = () => { };
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
            scoreboard.UpScore(ScoringConstants.ITEM_SCORE);
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
            scoreboard.UpScore(ScoringConstants.ENEMY_SCORE);
        }

        public void Die()
        {
            GameObjectPhysics.MoveMaxSpeed(Side.Up);
            World.Instance.MaskCollision(this);
            scoreboard.Die();
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

        public void ClimbDown()
        {
            State.ClimbDown();
        }

        public void ClimbUp()
        {
            State.ClimbUp();
        }

        public void Coin()
        {
            scoreboard.UpScore(ScoringConstants.COIN_SCORE);
            scoreboard.Collect();
        }
    }
}
