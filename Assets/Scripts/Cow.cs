using UnityEngine;

namespace Testo
{
    internal sealed class Cow : IMove
    {
        private readonly IMove _moveImplementation;

        public float Speed => _moveImplementation.Speed;
        public float JumpForce => _moveImplementation.JumpForce;

        public Cow(IMove moveImplementation)
        {
            _moveImplementation = moveImplementation;
        }

        public void Move(float horizontal, float vertical, bool jump)
        {
            _moveImplementation.Move(horizontal, vertical, jump);
        }
    }
}
