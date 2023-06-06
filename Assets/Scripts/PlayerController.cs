using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Joystick _joystick;

    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed = 5f;
    private float _x, _y, _z;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _x = _joystick.Horizontal;
        _y = _joystick.Vertical;
        _z = Mathf.Atan2(_x, _y) * Mathf.Rad2Deg;
        _rb.velocity = new Vector2(_x * _moveSpeed, _y * _moveSpeed);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, -_z);
        }
    }
}
