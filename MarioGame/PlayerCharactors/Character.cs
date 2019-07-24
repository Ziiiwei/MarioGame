using Gamespace.Characters;
using Gamespace.Multiplayer;
using Gamespace.Projectiles;
using Gamespace.Sounds;
using Gamespace.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
        internal class Character : AbstractGameStatefulObject<ICharacterState>, ICharacter
        {
            public ICharacterPowerUpState PowerUpState { get; set; }
            public Scoreboard scoreboard { get; set; }
            private Action keepStanding;

            private bool jumpKeyPressed;
            private bool jumpKeyHolded;
            private bool previouslyJumpKeyPressed;



            public Character(Vector2 positionOnScreen) : base(positionOnScreen)
            {
                State = new RightStandingCharacterState(this);
                PowerUpState = new StarCharacterState();
                SetSprite();
       
                keepStanding = () => State.Stand();
                DrawPriority = 1;
                jumpKeyPressed = false;
                jumpKeyHolded = false;
                previouslyJumpKeyPressed = false;
            }

            public Character(Vector2 positionOnScreen, Scoreboard scoreboard) : this(positionOnScreen)
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

                jumpKeyHolded = jumpKeyPressed && previouslyJumpKeyPressed;
                previouslyJumpKeyPressed = jumpKeyPressed;
                jumpKeyPressed = false;
            }

            public void Crouch()
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

            public virtual void PowerUp()
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
                GameObjectPhysics.Jump();
                scoreboard.UpScore(ScoringConstants.ENEMY_SCORE);
            }

            public void Die()
            {
                GameObjectPhysics.Jump();

                GameObjectPhysics.Stop(Side.Horizontal);
                World.Instance.MaskCollision(this);
                scoreboard.Die();
                SoundManager.Instance.PlaySoundEffect("MarioDies");

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
            }

            public virtual void ClimbDown()
            {
                State.ClimbDown();
            }

            public virtual void ClimbUp()
            {
                State.ClimbUp();
            }

            public virtual void GetCoin()
            {
                scoreboard.UpScore(ScoringConstants.COIN_SCORE);
                scoreboard.Collect();
            }

            public virtual bool Jumpable()
            {
                jumpKeyHolded = jumpKeyPressed && previouslyJumpKeyPressed;

                return ((State.Jumpable() ^ jumpKeyHolded) & !GameObjectPhysics.MaxSpeedReached(Side.Up));
            }
        }
    }