using Gamespace.Sprites;
using Gamespace.States;
using Microsoft.Xna.Framework;

namespace Gamespace
{
    public interface IMario : IGameObject
    {
        ISprite Sprite { get; set; }
        IMarioState State { get; set; }
        IMarioPowerUpState PowerUpState { get; set; }

        void Bounce();
        void Jump();
        void MoveRight();
        void MoveLeft();
        void Crouch();
        void PowerDown();
        void PowerUp();
        void UpdateArt();
        void CollideLeft(Rectangle collisionArea);
        void CollideRight(Rectangle collisionArea);
        void CollideUp(Rectangle collisionArea);
        void CollideDown(Rectangle collisionArea);
    }

}
