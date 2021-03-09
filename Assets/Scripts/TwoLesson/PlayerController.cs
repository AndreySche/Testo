using UnityEngine;
using System;

namespace Testo
{
    public class PlayerController
    {
        #region Variables
        private const float _walkSpeed = 3f,
                            _animationSpeed = 15f,
                            _jumpStartSpeed = 8f,
                            _jumpForce = 10f,
                            _jumpTresh = 0.1f,
                            _movingThresh = 0.1f,
                            _flyThresh = 1f,
                            _groundLevel = 0.5f,
                            _g = -10f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1),
                        _rightScale = new Vector3(1, 1, 1);

        private float _yVelocity = 0;
        private bool _doJump;
        private float _xAxisInput;

        private LevelObjectView _view;
        private SpriteAnimatorController _spriteAnimator;
        private readonly ContactsPoller _contactsPoller;
        #endregion

        public PlayerController(LevelObjectView view, SpriteAnimatorController spriteAnimator)
        {
            _view = view;
            _spriteAnimator = spriteAnimator;
            _contactsPoller = new ContactsPoller(_view._collider2D);
        }

        void GoSideWay()
        {
            _view._transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public void FixedUpdate()
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            _contactsPoller.Update();
            var walks = Mathf.Abs(_xAxisInput) > _movingThresh;

            var newVelocity = 0f;

            if (walks && 
                (_xAxisInput > 0 || !_contactsPoller.HasLeftContacts) && 
                (_xAxisInput < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
                Debug.Log("New Velocity");
            }

            if (walks && _contactsPoller.IsGrounded) GoSideWay();

            _view._rigidbody2D.velocity = _view._rigidbody2D.velocity.Change(x: newVelocity);

            if (_contactsPoller.IsGrounded && _doJump && Mathf.Abs(_view._rigidbody2D.velocity.y) <= _jumpTresh)
            {
                _view._rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }


            if (_contactsPoller.IsGrounded)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, walks ? AnimState.Run : AnimState.Idle, true, _animationSpeed);
            }
            else if (Mathf.Abs(_view._rigidbody2D.velocity.y) > _flyThresh)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, false, _animationSpeed);
            }
        }

    }
}
