namespace Sprint2
{
    public interface IMario : IGameObject
    {
        ISprite Sprite { get; set; }
        void Jump();
        void MoveRight();
        void MoveLeft();
        void Crouch();
        void TakeDamage();
        void Upgrade();
        void SetState(IMarioState newState);

    }
}
