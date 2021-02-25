namespace Testo
{
    public interface IMove
    {
        float Speed { get; }
        float JumpForce { get; }

        void Move(float horizontal, float vertical, bool jump);
    }
}
