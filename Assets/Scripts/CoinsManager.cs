using System;
using UnityEngine;
using System.Collections.Generic;

namespace Testo
{
    public class CoinsManager : IDisposable
    {
        private const float _animationsSpeed = 10f;

        private LevelObjectView _characterView;
        private SpriteAnimatorController _spriteAnimator;
        private List<LevelObjectView> _coinViews;

        public CoinsManager(LevelObjectView characterView, List<LevelObjectView> coinViews, SpriteAnimatorController spriteAnimator)
        {
            try
            {
                _characterView = characterView;
                _spriteAnimator = spriteAnimator;
                _coinViews = coinViews;
                _characterView.OnLevelObjectContact += OnLevelObjectContact;

                foreach (var child in coinViews)
                {
                    _spriteAnimator.StartAnimation(child._spriteRenderer, AnimState.Run, true, _animationsSpeed);
                }
            }
            catch
            {
                Debug.Log("Error");
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView._spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }

}
