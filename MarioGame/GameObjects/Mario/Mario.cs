using Gamespace.Sprites;
using Gamespace.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Gamespace
{
    internal class Mario : AbstractGameStatefulObject<IMarioState>, IMario
    {
        public IMarioPowerUpState PowerUpState { get; set; }
        public IMarioPowerUpState PreviousState { get; set; }

        public int score { get; set; }

        public Timer timer { get; }

        public Scoreboard scoreboard { get; }

        public Mario(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new RightStandingMarioState(this);
            PowerUpState = new MarioSmallState();
            scoreboard = new Scoreboard(this);
            timer = new Timer(400000);
            timer.Start();
            SetSprite();
        }

        public override void Update()
        {
            base.Update();
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
            PowerUpState.PowerUp(this);
            scoreboard.UpScore(ScoreConstants.ITEM_SCORE);
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
            scoreboard.UpScore(ScoreConstants.ENEMY_SCORE);
        }

        public void Die()
        {
            GameObjectPhysics.MoveMaxSpeed(Side.Up);
            World.Instance.MaskCollision(this);
        }

        public override void CollideDown(Rectangle collisionArea)
        {
            base.CollideDown(collisionArea);
            State.Land();
        }

        public void Fire()
        {
            State.Fire();
        }
    }
}
