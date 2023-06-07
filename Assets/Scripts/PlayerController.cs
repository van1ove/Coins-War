using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviourPun
{
    [Header("UI")]
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI name;
    
    [Header("Movement")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D _rb;
    private Animator _animator;
    private PhotonView _view;

    private float _x, _y, _z;
    private bool _isRunning = false;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        
        _animator = GetComponent<Animator>();
        
        _view = GetComponent<PhotonView>();
        name.text = _view.Owner.NickName;
        if (_view.Owner.IsLocal) Camera.main.GetComponent<CameraFollow>().player = gameObject.transform;
        
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }

    private void Update()
    {
        canvas.transform.eulerAngles = new Vector3(0f, 0f, -transform.rotation.z);
    }

    private void FixedUpdate()
    {
        _x = joystick.Horizontal;
        _y = joystick.Vertical;
        
        if (_view.IsMine)
        {
            _z = Mathf.Atan2(_x, _y) * Mathf.Rad2Deg;
            _rb.velocity = new Vector2(_x * moveSpeed, _y * moveSpeed);

            _isRunning = (_rb.velocity != Vector2.zero); 
            _animator.SetBool("IsRunning", _isRunning);
            
            if (_x != 0 || _y != 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, -_z);
            }
        }
    }
}
