using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private PhotonView _bulletView; 
    public float lifetime = 5f;
    private float _timer;
    
    private void Start()
    {
        _bulletView = GetComponent<PhotonView>();
        _timer = 0f;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= lifetime && _bulletView.IsMine)
        {
            PhotonNetwork.Destroy(bullet);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.layer is 6 or 3)
        {
            PhotonNetwork.Destroy(bullet);
        }
    }
}