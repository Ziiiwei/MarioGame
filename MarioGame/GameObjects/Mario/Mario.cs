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
        ISprite IMario.Sprite { get; set; }

        public Mario(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new RightStandingMarioState(this);
            PowerUpState = new MarioSmallState();
            SetSprite();
        }

        public override void Update()
        {
            base.Update();

            GameObjectPhysics.Update();
            GameObjectPhysics.FrictionStop(Side.Right);

            positionOnScreen = GameObjectPhysics.GetPosition();  
        }
        public void Crouch()
        {
            State.Crouch();    
        }

        public void Jump()
        {
            State.Jump();
            GameObjectPhysics.MoveMaxSpeed(Side.Up);
        }

        public void MoveLeft()
        {
            State.MoveLeft();
            GameObjectPhysics.Move(Side.Left);
        }

        public void MoveRight()
        {
            State.MoveRight();
            GameObjectPhysics.Move(Side.Right);
        }

        public void PowerDown()
        {
            PowerUpState.PowerDown(this);
            UpdateArt();
        }

        public void PowerUp()
        {
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
        }
    }
}
