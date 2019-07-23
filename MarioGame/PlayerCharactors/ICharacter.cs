using Gamespace.Projectiles;
using Gamespace.Sprites;
using Gamespace.States;
using Microsoft.Xna.Framework;
using Gamespace.Multiplayer;

namespace Gamespace
{
    public interface ICharacter : IGameObject
    {
        ISprite Sprite { get; }
        ICharacterState State { get; set; }
        ICharacterPowerUpState PowerUpState { get; set; }
        IPhysics GameObjectPhysics { get; set; }

        Scoreboard scoreboard { get; set; }
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
        void GetCoin();
        bool Jumpable();
    }

}
