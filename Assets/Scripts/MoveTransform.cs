using UnityEngine;

namespace Testo
{
    internal class MoveTransform : IMove
    {
        readonly Rigidbody2D _rigibBody2D;
        Vector3 _move;

        public float Speed { get; protected set; }
        public float JumpForce { get; protected set; }

        LevelObjectView _playerView;
        SpriteAnimator _spriteAnimator;
        float _animationSpeed;

        public MoveTransform(LevelObjectView playerView, float speed, float jumpForce, SpriteAnimator spriteAnimator, float animationSpeed)
        {
            _playerView = playerView;
            _rigibBody2D = playerView._rigidbody2D;

            Speed = speed;
            JumpForce = jumpForce;
            _spriteAnimator = spriteAnimator;
            _animationSpeed = animationSpeed;
        }

        public void Move(float horizontal, float vertical, bool jump)
        {
            vertical = _rigibBody2D.velocity.y;
            float jumpForce = jump ? vertical + JumpForce : vertical;
            _move.Set(horizontal * Speed, jumpForce, 0.0f);
            _rigibBody2D.velocity = _move;

            if (_rigibBody2D.velocity.y == 0 && _rigibBody2D.velocity.x == 0 )
                _spriteAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            else if (jump)
                _spriteAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Jump, false, _animationSpeed);
            else if (_rigibBody2D.velocity.x != 0)
                _spriteAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, _animationSpeed);
        }
    }
}
