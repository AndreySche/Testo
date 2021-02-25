using System.Collections.Generic;
using UnityEngine;

namespace Testo
{
    public class Main : MonoBehaviour
    {
        [SerializeField] Camera _camera;
        [SerializeField] LevelObjectView _playerView = null;
        [SerializeField] int _animationSpeed = 10;

        SpriteAnimator _playerAnimator;

        float _speed = 5f;
        float _jumpForce = 15f;
        Cow _cow;

        void Awake()
        {
            SpriteAnimatorConfig playerConfig = Resources.Load<SpriteAnimatorConfig>("SpritePlayerCfg");
            _playerAnimator = new SpriteAnimator(playerConfig);

            var moveTransform = new MoveTransform(_playerView, _speed, _jumpForce, _playerAnimator, _animationSpeed);
            _cow = new Cow(moveTransform);
        }

        void Update()
        {
            _playerAnimator.Update();
            _cow.Move(Input.GetAxis("Horizontal"), 0, Input.GetButtonDown("Jump"));
        }
    }
}