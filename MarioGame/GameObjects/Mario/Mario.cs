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
using Gamespace.Data;

namespace Gamespace
{
    internal class Mario : AbstractGameStatefulObject<IMarioState>, IMario
    {
        public IMarioPowerUpState PowerUpState { get; set; }

        public ILauncher Launcher { get; set; }
        public  Scoreboard scoreboard { get; set; }

        private Action keepStanding;

        protected IPlayer player;
        protected DiscreteTimer deathTimer;
        
        private bool jumpKeyPressed;
        private bool jumpKeyHolded;
        private bool previouslyJumpKeyPressed;
      


        public Mario(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new RightStandingMarioState(this);
            PowerUpState = new MarioSmallState();
            SetSprite();    
            keepStanding= () => State.Stand();
            DrawPriority = 1;
            jumpKeyPressed = false;
            jumpKeyHolded = false;
            previouslyJumpKeyPressed = false;
            Launcher = CharacterWeapeonManager.Instance.GetWeapeon(this);
        }

        public Mario(Vector2 positionOnScreen, Scoreboard scoreboard) : this(positionOnScreen)
        {
            this.scoreboard = scoreboard;
            scoreboard.MaxAmmo = Launcher.MaxProjectiles;
        }

        public Mario(Vector2 positionOnScreen, Scoreboard scoreboard, IPlayer player) : this(positionOnScreen, scoreboard)
        {
            this.scoreboard = scoreboard;
            this.player = player;
        }

        protected override void SurrogateUpdate()
        {
            base.SurrogateUpdate();
            GameObjectPhysics.Update();
            State.FrictionStop();
            positionOnScreen = GameObjectPhysics.Position;
            keepStanding.Invoke();
            keepStanding = () => State.Stand();

            jumpKeyHolded = jumpKeyPressed && previouslyJumpKeyPressed;
            previouslyJumpKeyPressed = jumpKeyPressed;
            jumpKeyPressed = false;

            Launcher.Update();

            deathTimer?.Tick();
        }

        public virtual void Crouch()
        {           
            State.Crouch();         
            keepStanding = () => { };
        }

        public virtual void Jump()
        {
            jumpKeyPressed = true;
            if (Jumpable())
            {
                State.Jump();
            }           
           
        }

        public virtual void MoveLeft()
        {
            State.MoveLeft();
        }

        public virtual void MoveRight()
        {
            State.MoveRight();
        }

        public virtual void PowerDown()
        {
            PowerUpState.PowerDown(this);
            UpdateArt();
        }

        public virtual  void PowerUp()
        {
            SoundManager.Instance.PlaySoundEffect("PowerUp");
            PowerUpState.PowerUp(this);
        }

        public virtual void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, PowerUpState.GetType().Name);
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, PowerUpState.GetType().Name);
        }

        public virtual void Bounce()
        {
            GameObjectPhysics.Jump();
        }

        public virtual void Die()
        {
            GameObjectPhysics.Jump();
            State = new MarioDeadState(this);
            UpdateArt();
            World.Instance.MaskCollision(this);
            ((MarioPhysics)GameObjectPhysics).Die();
            scoreboard?.Die();
            SoundManager.Instance.PlaySoundEffect("MarioDies");
            deathTimer = new DiscreteTimer(100, new Action(() => { player?.Respawn(); World.Instance.RemoveFromWorld(this); }));
            
      
        }
        public override void CollideDown(Rectangle collisionArea)
        {
            base.CollideDown(collisionArea);
            State.Land();

            if (!jumpKeyHolded)
            {
                ((MarioPhysics)GameObjectPhysics).ReSetMaxSpeedCheck();
            }

        }

        public virtual void Fire()
        {
             PowerUpState.Fire(this);
        }

        public virtual void ClimbDown()
        {
            State.ClimbDown();
        }

        public virtual void ClimbUp()
        {
            State.ClimbUp();
        }

        public virtual void Coin()
        {
        }

        public virtual bool Jumpable()
        {
            jumpKeyHolded = jumpKeyPressed && previouslyJumpKeyPressed;

            return ((State.Jumpable()^jumpKeyHolded)&!GameObjectPhysics.MaxSpeedReached(Side.Up));
        }
        
        public void ScoreKill()
        {
            scoreboard.UpScore(1);
        }
    }
}
