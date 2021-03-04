using UnityEngine;
using System;

namespace Testo
{
    public class PlayerMove 
    {
        #region Variables
        const float _walkSpeed = 3f,
                    _animationSpeed = 15f,
                    _jumpStartSpeed = 8f,
                    _movingThresh = 0.1f,
                    _flyThresh = 1f,
                    _groundLevel = 0.5f,
                    _g = -10f;

        Vector3 _leftScale = new Vector3(-1, 1, 1),
                _rightScale = new Vector3(1, 1, 1);

        float _yVelocity = 0;
        bool _doJump;
        float _xAxisInput;

        LevelObjectView _view;
        SpriteAnimator _spriteAnimator;
        #endregion

        public PlayerMove(LevelObjectView view, SpriteAnimator spriteAnimator)
        {
            _view = view;
            _spriteAnimator = spriteAnimator;
        }

        void GoSideWay()
        {
            _view._transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public bool IsGrounded()
        {
            return _view._transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
        }

        public void Update()
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            var goSideWay = Mathf.Abs(_xAxisInput) > _movingThresh;

            if (IsGrounded())
            {
                if (goSideWay) GoSideWay(); // walking
                _spriteAnimator.StartAnimation(_view._spriteRenderer,goSideWay?AnimState.Run:AnimState.Idle,true,_animationSpeed);

                if (_doJump && _yVelocity == 0) _yVelocity = _jumpStartSpeed; // start Jump
                else if (_yVelocity < 0) // stop Jump
                {
                    _yVelocity = 0;
                    _view._transform.position = _view._transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                if (goSideWay) GoSideWay(); // flying
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, false, _animationSpeed);
                }
                _yVelocity += _g * Time.deltaTime;
                _view._transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }
    }
}
