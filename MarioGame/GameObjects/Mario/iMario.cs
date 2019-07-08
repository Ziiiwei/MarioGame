using Gamespace.Sprites;
using Gamespace.States;
using Microsoft.Xna.Framework;
using System.Timers;

namespace Gamespace
{
    public interface IMario : IGameObject
    {
        ISprite Sprite { get; }
        IMarioState State { get; set; }
        IMarioPowerUpState PowerUpState { get; set; }
        IMarioPowerUpState PreviousState { get; set; }
        IPhysics GameObjectPhysics { get; set; }
        Timer timer { get;  }
        Scoreboard scoreboard { get; }

        int score { get; set; }

        void Bounce();
        void Jump();
        void MoveRight();
        void MoveLeft();
        void Crouch();
        void PowerDown();
        void PowerUp();
        void Fire();
        void UpdateArt();
        void Die();
        void CollideLeft(Rectangle collisionArea);
        void CollideRight(Rectangle collisionArea);
        void CollideUp(Rectangle collisionArea);
        void CollideDown(Rectangle collisionArea);
    }

}
