using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 15f;

    Rigidbody2D _rigibBody;
    Vector3 _directory = new Vector3(0, 0, 0);
    bool _landContact = false;
    string _contactTag;

    void Start() => _rigibBody = GetComponent<Rigidbody2D>();

    void Update()
    {
        _directory.y = _rigibBody.velocity.y;
        _directory.x = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButtonDown("Jump")) Jump();
        _rigibBody.velocity = _directory;
    }

    private void Jump()
    {
        if (!_landContact) return;

        _directory.y = jumpForce;
        _landContact = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_landContact) return;
        _contactTag = collision.gameObject.tag;
        if ((_contactTag == "Ground" || _contactTag == "Enemy") && !_landContact)
        {
            _landContact = true;
        }
    }
}