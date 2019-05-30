namespace Sprint2
{
    public interface IMario : IGameObject
    {
        ISprite Sprite { get; set; }
        IMarioPowerUpState PowerUpState { get; set; }
        void Jump();
        void MoveRight();
        void MoveLeft();
        void Crouch();
        void PowerDown();
        void PowerUp();
        void SetState(IMarioState newState);

    }
}
