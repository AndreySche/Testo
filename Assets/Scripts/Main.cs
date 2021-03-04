using System.Collections.Generic;
using UnityEngine;

namespace Testo
{
    public class Main : MonoBehaviour
    {
        [SerializeField] LevelObjectView _playerView = null;
        [SerializeField] SpriteAnimatorConfig _playerConfig;
        [SerializeField] Transform _cannon = null;

        SpriteAnimator _playerAnimator;
        PlayerMove _playerController;
        AimingMuzzle _muzzle;

        void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("SpritePlayerCfg");
            _playerAnimator = new SpriteAnimator(_playerConfig);
            _playerController = new PlayerMove(_playerView, _playerAnimator);
            _muzzle = new AimingMuzzle(_cannon, _playerView._transform);
        }

        void Update()
        {
            _playerAnimator.Update();
            _playerController.Update();
            _muzzle.Update();
        }
    }
}