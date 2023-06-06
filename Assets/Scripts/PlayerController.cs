using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviourPun
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private PhotonView _view;

    private float _x, _y, _z;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        
        _animator = GetComponent<Animator>();
        _view = GetComponent<PhotonView>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();

        if (_view.Owner.IsLocal) Camera.main.GetComponent<CameraFollow>().player = gameObject.transform;
    }

    private void FixedUpdate()
    {
        _x = joystick.Horizontal;
        _y = joystick.Vertical;
        
        if (_view.IsMine)
        {
            _z = Mathf.Atan2(_x, _y) * Mathf.Rad2Deg;
            _rb.velocity = new Vector2(_x * moveSpeed, _y * moveSpeed);
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, -_z);
            }    
        }
    }
}
