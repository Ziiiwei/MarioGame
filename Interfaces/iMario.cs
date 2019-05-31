using Gamespace.Sprites;

namespace Gamespace
{
    public interface IMario : IGameObject
    {
        ISprite Sprite { get; set; }
        IMarioState State { get; set; }
        IMarioPowerUpState PowerUpState { get; set; }
        void Jump();
        void MoveRight();
        void MoveLeft();
        void Crouch();
        void PowerDown();
        void PowerUp();
        void UpdateArt();
    }
}
