using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Testo
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Rigidbody2D _rigidbody2D;
        public Collider2D _collider2D;


        #region Tmp variables
        //public float speed = 5f;
        //public float jumpForce = 15f;

        //public bool landContact = false;
        //string _contactTag;

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (landContact) return;

        //    _contactTag = collision.gameObject.tag;
        //    if (_contactTag == "Ground") landContact = true;
        //}
        #endregion
    }
}
