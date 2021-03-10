using UnityEngine;
using System;

namespace Testo
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Rigidbody2D _rigidbody2D;
        public Collider2D _collider2D;

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        void OnTriggerEnter2D(Collider2D collider)
        {
            var levelObject = collider.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}
