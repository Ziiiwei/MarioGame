using Gamespace.Sprites;
using Gamespace.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class Mario : AbstractGameStatefulObject<IMarioState>, IMario
    {
        public IMarioPowerUpState PowerUpState { get; set; }

        public IMarioPowerUpState PreviousState { get; set; }
        ISprite IMario.Sprite { get; set; }

        int timer = 1000;

        public Mario(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            State = new RightStandingMarioState(this);
            PowerUpState = new MarioSmallState();
            SetSprite();
        }

        public override void Update()
        {
            GameObjectPhysics.Update();
            GameObjectPhysics.FrictionStop(Side.Right);
            if (GameObjectPhysics.Position.X<0)
            {
                CollideLeft(new Rectangle(-(int)GameObjectPhysics.Position.X, 1, 1, 1));
            }
            positionOnScreen = GameObjectPhysics.GetPosition();
            if (PowerUpState.GetType() == typeof(StarMarioState) || PowerUpState.GetType() == typeof(SmallStarMarioState))
            {
                timer--;
                if(timer == 0)
                {
                    PowerUpState = PreviousState;
                    timer = 1000;
                }
            }
            if (positionOnScreen.Y >= 1000)
                World.Instance.end = 1;
            base.Update();
        }
        public void Crouch()
        {
            State.Crouch();    
        }

        public void Jump()
        {
            State.Jump();
            GameObjectPhysics.JumpMaxSpeed(Side.Up);
        }

        public void MoveLeft()
        {
            State.MoveLeft();
            GameObjectPhysics.MoveMaxSpeed(Side.Left);
        }

        public void MoveRight()
        {
            State.MoveRight();
            GameObjectPhysics.MoveMaxSpeed(Side.Right);
        }

        public void PowerDown()
        {
            PowerUpState.PowerDown(this);
            UpdateArt();
        }

        public void PowerUp()
        {
            PreviousState = PowerUpState;
            PowerUpState.PowerUp(this);
            UpdateArt();
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
            GameObjectPhysics.JumpMaxSpeed(Side.Up);
        }

        public void GoStar()
        {
            PreviousState = PowerUpState;
            PowerUpState = new StarMarioState();
            if (PreviousState.GetType() == typeof(MarioSmallState))
                PowerUpState = new SmallStarMarioState();
            UpdateArt();
        }

        public void Die()
        {
            GameObjectPhysics.JumpMaxSpeed(Side.Up);
            World.Instance.MaskCollision(this);
        }
    }
}
