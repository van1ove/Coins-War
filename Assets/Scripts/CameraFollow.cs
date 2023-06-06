using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _playerVector;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        _playerVector = _player.position;
        _playerVector.z = -10;
        transform.position = Vector3.Lerp(transform.position, _playerVector, _speed * Time.deltaTime);
    }
}
