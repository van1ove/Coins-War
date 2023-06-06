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
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float x = _joystick.Horizontal;
        float y = _joystick.Vertical;
        float z = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
        _rb.velocity = new Vector2(x * _moveSpeed, y * _moveSpeed);
        //Debug.Log(Quaternion.LookRotation(_rb.velocity));
        //Debug.Log(_rb.velocity);
        //Debug.Log(_joystick.Direction);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, -z);
            //transform.rotation = Quaternion.LookRotation(Vector2.up, _rb.velocity);
        }
    }
}
