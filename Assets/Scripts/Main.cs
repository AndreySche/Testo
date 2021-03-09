using System.Collections.Generic;
using UnityEngine;

namespace Testo
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView = null;
        [SerializeField] private List<LevelObjectView> _coins = null;
        [SerializeField] private CannonView _cannon;    

        private CannonAimController _cannonAim;
        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinsAnimator;
        private PlayerController _playerController;
        private CoinsManager _coinsManager;

        void Awake()
        {
            SpriteAnimatorConfig playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimatorCfg");
            _playerAnimator = new SpriteAnimatorController(playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);

            SpriteAnimatorConfig coinsConfig = Resources.Load<SpriteAnimatorConfig>("CoinsAnimatorCfg");
            _coinsAnimator = new SpriteAnimatorController(coinsConfig);

            _cannonAim = new CannonAimController(_cannon._muzzleTransform, _playerView.transform);
            _coinsManager = new CoinsManager(_playerView, _coins, _coinsAnimator);
        }

        void Update()
        {
            _playerAnimator.Update();
            _cannonAim.Update();
            _coinsAnimator.Update();
        }

        private void FixedUpdate()
        {
            _playerController.FixedUpdate();
        }
    }
}